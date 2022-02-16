using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInteraction : MonoBehaviour
{
    public AsteroidGameManager GameManager;

    public AudioSource sound;

    public void Destroy()
    {
        sound.Play(); // TODO : Jouer le son dans le GameManager ??
        //GameManager.AsteroidDestroyed();
        this.gameObject.SetActive(false);
    }

}
