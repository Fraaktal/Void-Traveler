using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnRotation : MonoBehaviour
{
    public GameObject gameObject;
    public AudioSource audioSource;
    bool hasPlayed = false;
    private bool CanPlay = false;
    
    public Action HasWon { get; set; }

    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    void Update()
    {
        if (CanPlay)
        {
            if (transform.rotation.x <= -0.6)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                if (!hasPlayed)
                {
                    audioSource.Play();
                    hasPlayed = true;
                }
                HasWon?.Invoke();
            }
        }
    }

    public void StartGame()
    {
        CanPlay = true;
    }
}