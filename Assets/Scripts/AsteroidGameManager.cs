using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGameManager : MonoBehaviour
{
    public GameObject AsteroidSpawner;
    public GameObject Asteroid; //TODO Prevoir de faire varier les modèles d'Asteroid

    public int MaxSpawnDelay;
    public int MinSpawnDelay;
    public int NbAsteroidToDestroy;

    private int frameCounter;
    private int asteroidCounter; //TODO Mettre fin au mini jeu après X asteroids détruits
    private int spawnDelay;

    private bool gameIsActive = false;

    public void Launch()
    {
        asteroidCounter = 0;
        ReinitCounter();
        gameIsActive = true;
    }

    public void AsteroidDestroyed()
    {
        asteroidCounter++;
        if(asteroidCounter >= NbAsteroidToDestroy)
        {
            Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsActive)
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
        this.gameObject.SetActive(false);
    }

    private void ReinitCounter()
    {
        frameCounter = 0;
        spawnDelay = Random.Range(MinSpawnDelay, MaxSpawnDelay);
    }

    private void ThrowAsteroid()
    {
        var obj = Instantiate(Asteroid);
        // TODO paramétrer l'angle min et max ??
        float randX = Random.Range(-0.15f, 0.15f);
        float randY = Random.Range(-0.15f, 0.15f);
        Vector3 vec = new Vector3(randX ,
            randY ,
            AsteroidSpawner.transform.forward.z);

        obj.transform.position = AsteroidSpawner.transform.position;
        obj.GetComponent<Rigidbody>().AddForce(5500 * vec, ForceMode.Impulse);
    }
}
