using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAsteroids : MonoBehaviour
{
    public AsteroidGameManager Asteroids;
    // Start is called before the first frame update
    void Start()
    {
        Asteroids.CanStartGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
