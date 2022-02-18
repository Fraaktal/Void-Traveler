using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAll : MonoBehaviour
{
    public GameObject interrupteur;

    public List<VoidLight> lights;
    public Material lightOff;

    private bool isInterruptorDisabled;

    private bool interrupteurState = false;

    public void Switch()
    {
        if (!isInterruptorDisabled)
        { 
            if (interrupteurState)
            {
                interrupteurState = false;
                interrupteur.transform.Rotate(0, 30, 0, Space.Self);
            }
            else
            {
                interrupteurState = true;
                interrupteur.transform.Rotate(0, -30, 0, Space.Self);
            }

            foreach (var voidLight in lights)
            {
                if (voidLight.isOn)
                {
                    voidLight.GetComponent<Renderer>().material = lightOff;
                    voidLight.isOn = false;
                }
            }
        }
    }

    public void SetInterruptorDisabled()
    {
        isInterruptorDisabled = true;
    }
}