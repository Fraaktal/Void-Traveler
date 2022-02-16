using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGameManager : MonoBehaviour
{
    public GameObject AsteroidSpawner;
    public GameObject Asteroid; //TODO Prevoir de faire varier les mod�les d'Asteroid

    public int MaxSpawnDelay;
    public int MinSpawnDelay;
    public int NbAsteroidToDestroy;

    private int frameCounter;
    private int asteroidCounter; //TODO Mettre fin au mini jeu apr�s X asteroids d�truits
    private int spawnDelay;

    private bool gameIsActive = false;

    public void Launch()
    {
        asteroidCounter = 0;
        ReinitCounter();
        gameIsActive = true;
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

    void Stop()
    {

    }

    private void ReinitCounter()
    {
        frameCounter = 0;
        spawnDelay = Random.Range(MinSpawnDelay, MaxSpawnDelay);
    }

    private void ThrowAsteroid()
    {
        var obj = Instantiate(Asteroid);
        // TODO param�trer l'angle min et max ??
        float randX = Random.Range(-0.25f, 0.25f);
        float randY = Random.Range(-0.25f, 0.25f);
        Vector3 vec = new Vector3(randX ,
            randY ,
            AsteroidSpawner.transform.forward.z);

        obj.transform.position = AsteroidSpawner.transform.position;
        obj.GetComponent<Rigidbody>().AddForce(5000 * vec, ForceMode.Impulse);

        //obj.transform.position = transform.position + 2 * AsteroidSpawner.transform.forward;
        //obj.GetComponent<Rigidbody>().AddForce(5000 * AsteroidSpawner.transform.forward, ForceMode.Impulse);
    }
}
