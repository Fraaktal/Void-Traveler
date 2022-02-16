using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInteraction : MonoBehaviour
{
    
    public void Destroy()
    {
        this.gameObject.SetActive(false);
    }
}
