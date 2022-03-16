using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportToOtherObject : MonoBehaviour
{
    public XRRig PlayerCam;
    public GameObject ObjectDestination;
    public float hauteurOffset = 1.5f;

    public void Teleport()
    {
        if (ObjectDestination != null)
        {
            var newPosition = new Vector3(ObjectDestination.transform.position.x, ObjectDestination.transform.position.y + hauteurOffset, ObjectDestination.transform.position.z);
            //PlayerCam.transform.position = newPosition;
            PlayerCam.MoveCameraToWorldLocation(newPosition);
            PlayerCam.MatchRigUp(new Vector3(0, 0, 0)); //Fixe l'angle up de la camera
        }

    }
}
