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
        
        private Vector3 initPositionController;

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
                var endpos = CalculateRopeEndPosition(transform.position, initPositionController, HandController.transform.forward);
                DrawLine(transform.position, endpos);
            }
        }

        private Vector3 CalculateRopeEndPosition(Vector3 origin, Vector3 initHand, Vector3 currentHand)
        {
            Vector3 res = new Vector3();
            res.x = origin.x + (currentHand.x - initHand.x)*2f;
            res.y = origin.y + (currentHand.y - initHand.y)*2f;
            res.z = origin.z + (currentHand.z - initHand.z)*2f;

            return res;
        }
        
        public void OnSelect()
        {
            if (!IsDone)
            {
                ShowLine = true;
                initPositionController = HandController.transform.forward;
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
