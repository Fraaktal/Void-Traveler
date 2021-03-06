using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Cables
{
    public class CablesController : MonoBehaviour
    {
        [HideInInspector]
        public CableOrigin CablingOrigin;
        public List<CableOrigin> Origins;
        public List<CableDestination> Destinations;
        public AudioSource VictorySound;
        public GameObject icon;

        private List<Tuple<CableOrigin, CableDestination>> Associations { get; set; }
        private int ValidatedCablesCount { get; set; }
        public Action HasWon;

        // Start is called before the first frame update
        void Start()
        {
        }

        public void StartGame()
        {
            Associations = GenerateAssociations();
            ValidatedCablesCount = 0;
        }

        //On génère aléatoirement des associations
        private List<Tuple<CableOrigin, CableDestination>> GenerateAssociations()
        {
            var result = new List<Tuple<CableOrigin, CableDestination>>();
            Random r = new Random();
        
            foreach (var origin in Origins)
            {
                int i = -1;
            
                //Si une destination est déjà utilisée on relance le random.
                while (i == -1 || result.Any(a => Equals(a.Item2, Destinations[i])))
                {
                    i = r.Next() % Destinations.Count;
                }

                origin.Destination = Destinations[i];
                origin.CablesController = this;
                Destinations[i].CablesController = this;
                Destinations[i].SetColor(origin.Color);
                
                result.Add(new Tuple<CableOrigin, CableDestination>(origin, Destinations[i]));
            }

            return result;
        }

        public void ValidateCables()
        {
            ValidatedCablesCount++;
            if (ValidatedCablesCount == Origins.Count)
            {
                VictorySound.Play();
                icon.SetActive(false);
                HasWon?.Invoke();
            }
        }

        public void SetCablingOrigin(CableOrigin origin)
        {
            foreach (var cableOrigin in Origins)
            {
                if (!Equals(cableOrigin,origin))
                {
                    cableOrigin.StopCabling();
                }
            }
            
            CablingOrigin = origin;
        }
    }
}
