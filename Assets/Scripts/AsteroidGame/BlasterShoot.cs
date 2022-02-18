using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterShoot : MonoBehaviour
{
    public AsteroidGameManager AsteroidGM;
    public AudioSource Sound;

    private bool lastTriggerValue = false;

    public void Shoot()
    {
        if (AsteroidGM.isGameActive)
        {
            Sound.Play();
        }
    }

    public void OnTriggerPressed(bool triggerValue)
    {
        if (isActiveAndEnabled && !lastTriggerValue && triggerValue)
        {
            Shoot();
        }

        lastTriggerValue = triggerValue;
    }
}
