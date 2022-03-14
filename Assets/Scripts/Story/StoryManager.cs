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
        public XRRig PlayerCam;
        public GameObject ObjectDestination;
        public VideoPlayer Video;
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
            bool hasEnded = PlayAudio(VoiceLinesSource[VoiceLineIndex], DoPlaySound);
            
            if (hasEnded)
            {
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
                    case 19:
                        PlayTheEnd();
                        break;
                    default:
                        IncrementAndPlay();
                        break;
                }
            }
        }
        
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

        }

        private void PlayEndGame()
        {
            if (DoPlayGame)
            {
                //on déplace au bon endroit
                var newPosition = new Vector3(ObjectDestination.transform.position.x, ObjectDestination.transform.position.y + 1.5f, ObjectDestination.transform.position.z);
                PlayerCam.MoveCameraToWorldLocation(newPosition);
                PlayerCam.MatchRigUp(new Vector3(0, 0, 0));
                Video.Play();
                DoPlayGame = false;
            }
            
        }

        private void PlayTheEnd()
        {

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
