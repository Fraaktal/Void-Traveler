using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInteractions : MonoBehaviour
{
    private bool isRotating = false;

    public AudioSource EngineSound;
    public Action OnFinished;
    public GameObject parent;

    public GameObject Spaceship;


    public void OnHoverEnter()
    {
        isRotating = true;
    }

    public void Reset(){
        isRotating = false; 
    }

    public void OnSelected()
    {
        Reset();
        EngineSound.Play();
        OnFinished?.Invoke();

        Spaceship.GetComponent<Animator>().SetBool("isTriggered", true);
    }

    private void Update()
    {
        if(isRotating)
            this.transform.Rotate(new Vector3(9f * Time.deltaTime, 2f * Time.deltaTime));
    }

    public void Show()
    {
        parent.SetActive(true);
    }

    public void Hide()
    {
        parent.SetActive(false);
    }
}
