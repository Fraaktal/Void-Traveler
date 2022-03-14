using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGameManager : MonoBehaviour
{
    public GameObject Asteroid1;
    public GameObject Asteroid2;
    public GameObject Asteroid3;
    public AudioSource DestroySound;
    public AudioSource ShootSound;

    public int MaxSpawnDelay;
    public int MinSpawnDelay;
    public int NbAsteroidToDestroy;

    private int frameCounter;
    private int asteroidCounter;
    private int spawnDelay;

    private List<GameObject> _listOfAsteroids;

    public bool isGameActive = false;

    #region Méthodes publiques

    public void Launch()
    {
        _listOfAsteroids = new List<GameObject>() { Asteroid1, Asteroid2, Asteroid3};
        asteroidCounter = 0;
        ReinitCounter();
        isGameActive = true;
        gameObject.SetActive(true);
    }

    public void AsteroidDestroyed()
    {
        DestroySound.Play();
        asteroidCounter++;
        if (asteroidCounter >= NbAsteroidToDestroy)
        {
            Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            if (frameCounter > spawnDelay)
            {
                ThrowAsteroid();
                ReinitCounter();
            }
            else
            {
                frameCounter++;
            }
        }        
    }

    public void Stop()
    {
        foreach(var asteroid in _listOfAsteroids)
            asteroid.SetActive(false);
        isGameActive = false;
        gameObject.SetActive(false);
    }

    #endregion

    #region Méthodes privées

    private void ReinitCounter()
    {
        frameCounter = 0;
        spawnDelay = Random.Range(MinSpawnDelay, MaxSpawnDelay);
    }

    private void ThrowAsteroid()
    {
        var _asteroid = _listOfAsteroids[Random.Range(0, _listOfAsteroids.Count)];
        var obj = Instantiate(_asteroid);
        obj.SetActive(true);
        _listOfAsteroids.Add(obj);

        // Génération de l'angle (semi) aléatoire
        float randomAngleX = Random.Range(-0.10f, 0.10f);
        float randomAngleY = Random.Range(-0.10f, 0.10f);
        Vector3 randomAngle = new Vector3(randomAngleX, randomAngleY, gameObject.transform.forward.z);

        // Génération de la position (semi) aléatoire
        float randomOffsetPosX = Random.Range(-5, 5);
        float randomOffsetPosY = Random.Range(-5, 5);
        float randomOffsetPosZ = Random.Range(-15, 15);
        Vector3 randomPos = new Vector3(gameObject.transform.position.x + randomOffsetPosX,
            gameObject.transform.position.y + randomOffsetPosY,
            gameObject.transform.position.z + gameObject.transform.forward.x + randomOffsetPosZ);

        obj.transform.position = randomPos;
        obj.GetComponent<Rigidbody>().AddForce(5500 * randomAngle, ForceMode.Impulse);
    }

    #endregion
}
