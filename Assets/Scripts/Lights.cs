using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource sound;
    public List<VoidLight> lights;
    public List<Light_Behavior> turnOns;
    public TurnOffAll turnOff;
    public Material lightWon;
    
    void Start()
    {
        this.enabled = false;
    }

    public void StartGame()
    {
        this.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Action HasWon { get; set; }

    public void Switch()
    {
        bool hasWon = true;
        foreach (var voidLight in lights)
        {
            if (!voidLight.isOn)
            {
                hasWon = false;
                break;
            }
        }

        if (hasWon)
        {
            //on a gagné
            foreach (var inter in turnOns)
            {
                inter.SetInterruptorDisabled();
            }

            foreach (var voidLight in lights)
            {
                voidLight.GetComponent<Renderer>().material = lightWon;
            }
            
            
            
            turnOff.SetInterruptorDisabled();
            sound.Play();
            HasWon?.Invoke();
        }
    }
}
