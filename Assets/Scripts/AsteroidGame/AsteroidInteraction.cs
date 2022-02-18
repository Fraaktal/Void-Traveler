using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInteraction : MonoBehaviour
{
    public AsteroidGameManager GameManager;

    public void Destroy()
    {
        GetComponent<ParticleEffectManager>().Activate();
        GameManager.AsteroidDestroyed();
        gameObject.SetActive(false);
    }

}
