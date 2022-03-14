using System.Collections.Generic;
using Cables;
using UnityEngine;

namespace Story
{
    public class StoryManager : MonoBehaviour
    {
        #region voice lines
        public List<AudioSource> VoiceLinesSource;
        #endregion

        #region games
        public CablesController CablesController;
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
                    case 8:
                        PlayLoadAndPay();
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
                    case 15:
                        PlayLanding();
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

        private void PlayLoadAndPay()
        {

        }

        private void PlayLights()
        {

        }

        private void PlayMap2()
        {

        }

        private void PlayAsteroids()
        {

        }

        private void PlayLanding()
        {

        }

        private void PlayValves()
        {

        }

        private void PlayEndGame()
        {

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
