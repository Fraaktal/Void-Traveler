using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Behavior : MonoBehaviour
{
    public GameObject interrupteur;

    public List<VoidLight> lights;
    public Material lightOn;
    public Material lightOff;

    private bool interrupteurState = false;
    private bool isInterruptorDisabled;

    // Start is called before the first frame update
    void Start()
    {
    }

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
                else
                {
                    voidLight.GetComponent<Renderer>().material = lightOn;
                    voidLight.isOn = true;
                }
            }
        }
    }

    public void SetInterruptorDisabled()
    {
        isInterruptorDisabled = true;
    }
}