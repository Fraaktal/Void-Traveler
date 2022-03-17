using System.Collections.Generic;
using Cables;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

namespace Story
{
    public class StoryManager : MonoBehaviour
    {
        #region voice lines
        public List<AudioSource> VoiceLinesSource;
        #endregion

        #region games
        public CablesController CablesController;
        public Lights Lights;
        public AsteroidGameManager AsteroidGameManager;
        public PlanetInteractions Garage;
        public PlanetInteractions Terre;
        public EffectOnRotation Valve;

        public TeleportToOtherObject TP;
        public GameObject ImageEnd;
        #endregion

        private int VoiceLineIndex;
        private bool DoPlaySound;
        private bool DoPlayGame;

        // Start is called before the first frame update
        void Start()
        {
            DoPlaySound = true;
            DoPlayGame = true;
            VoiceLineIndex = 0;
        }

        // Update is called once per frame
        void Update()
        {
            //On joue l'audio correspondant à l'index actuel
            bool hasEnded = PlayAudio(VoiceLinesSource[VoiceLineIndex], DoPlaySound);
            
            if (hasEnded)
            {
                //en fonction de l'index on lance un mini jeu si besoin
                switch (VoiceLineIndex)
                {
                    case 3:
                        PlayCables();
                        break;
                    case 4:
                        PlayMap1();
                        break;
                    case 9:
                        PlayLights();
                        break;
                    case 10:
                        PlayValves();
                        break;
                    case 12:
                        PlayMap2();
                        break;
                    case 13:
                        PlayAsteroids();
                        break;
                    case 16:
                        PlayValves();
                        break;
                    case 17:
                        PlayEndGame();
                        break;
                    default:
                        IncrementAndPlay();
                        break;
                }
            }
        }
        
        //incrémente l'index
        private void IncrementAndPlay()
        {
            VoiceLineIndex++;
            DoPlaySound = true;
            DoPlayGame = true;
        }

        private void PlayCables()
        {
            if (DoPlayGame)
            {
                CablesController.StartGame();
                DoPlayGame = false;
            }
            CablesController.HasWon += IncrementAndPlay;
        }

        private void PlayMap1()
        {
            Garage.Show();
            Garage.OnFinished += () =>
            {
                Garage.Hide();
                IncrementAndPlay();
            };
        }
        
        private void PlayLights()
        {
            if (DoPlayGame)
            {
                Lights.StartGame();
                DoPlayGame = false;
            }
            Lights.HasWon += IncrementAndPlay;
        }

        private void PlayMap2()
        {
            Terre.Show();
            Terre.OnFinished += () =>
            {
                Terre.Hide();
                IncrementAndPlay();
            };
        }

        private void PlayAsteroids()
        {
            if (DoPlayGame)
            {
                AsteroidGameManager.CanStartGame = true;
                DoPlayGame = false;
            }
            AsteroidGameManager.HasWon += IncrementAndPlay;
        }

        private void PlayValves()
        {
            Valve.StartGame();
            Valve.HasWon += IncrementAndPlay;
        }

        private void PlayEndGame()
        {
            if (DoPlayGame)
            {
                //on déplace au bon endroit
                TP?.Teleport();
                ImageEnd?.gameObject.SetActive(true);
                DoPlayGame = false;
            }
            
        }

        private bool PlayAudio(AudioSource audioSource, bool play)
        {
            if (play)
            {
                audioSource.Play();
                DoPlaySound = false;
            }

            return !audioSource.isPlaying;
        }
    }
}
