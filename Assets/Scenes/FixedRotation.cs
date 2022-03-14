using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FixedRotation : MonoBehaviour
{
    float z;
    float x;
    float y;

    void Update()
    {
        float h = Input.GetAxis("Horizontal") * 30 * Time.deltaTime;
        z = transform.eulerAngles.z;
        x = transform.eulerAngles.x;
        y = transform.eulerAngles.y;
        Vector3 desiredRot = new Vector3(x, y, z + h);
        if (desiredRot.z > 30)
        {
            desiredRot = new Vector3(x, y, 30);
        }
        else if (desiredRot.z < -30)
        {
            desiredRot = new Vector3(x, y, -30);
        }

        transform.rotation = Quaternion.Euler(desiredRot);
    }
}
