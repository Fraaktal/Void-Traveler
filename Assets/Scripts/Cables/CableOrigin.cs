using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Cables
{
    public class CableOrigin : MonoBehaviour
    {
        [HideInInspector]
        public CableDestination Destination;
        
        [HideInInspector]
        public CablesController CablesController;
        
        public Color Color;
        public GameObject HandController;
        public AudioSource SuccessSound;
        public AudioSource FailureSound;
        public Material RopeMaterial;
        
        private GameObject Line;
        private bool ShowLine;
        private bool IsDone;

        // Start is called before the first frame update
        void Start()
        {
            gameObject.GetComponent<Renderer>().material.color = Color;
        }

        // Update is called once per frame
        void Update()
        {
            
            if (ShowLine && !IsDone)
            {
                DrawLine(transform.position, HandController.transform.forward);
            }
        }

        public void OnSelect()
        {
            if (!IsDone)
            {
                ShowLine = true;
                CablesController.SetCablingOrigin(this);
            }
        }

        public void OnCableValidate(CableDestination destination)
        {
            //Le cable est bien mis
            if (Equals(destination, Destination) && !IsDone)
            {
                SuccessSound.Play();
                IsDone = true;
                DrawLine(transform.position, destination.transform.position);
                CablesController.ValidateCables();
            }
            else
            {
                if (!IsDone)
                {
                    FailureSound.Play();
                }
            }
        }

        void DrawLine(Vector3 start, Vector3 end)
        {
            if (Line != null)
            {
                Destroy(Line);
            }
            Line = new GameObject();
            Line.transform.position = start;
            Line.AddComponent<LineRenderer>();
            LineRenderer lr = Line.GetComponent<LineRenderer>();
            lr.material = RopeMaterial;
            lr.material.color = Color;
            lr.startColor = Color;
            lr.endColor = Color;
            lr.startWidth = 0.01f;
            lr.endWidth = 0.01f;
            lr.SetPosition(0, start);
            lr.SetPosition(1, end);
        }

        public void StopCabling()
        {
            if (!IsDone)
            {
                ShowLine = false;
                Destroy(Line);
            }
        }
    }
}
