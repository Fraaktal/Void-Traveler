using UnityEngine;

namespace Cables
{
    public class CableDestination : MonoBehaviour
    { 
        [HideInInspector]
        public CablesController CablesController;

        public void SetColor(Color color)
        {
            gameObject.GetComponent<Renderer>().material.color = color;
        }
        
        
        public void OnCableValidateSelected()
        {
            CablesController.CablingOrigin.OnCableValidate(this);
        }
    }
}
