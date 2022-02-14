using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiThere
{
    public class SoundController : MonoBehaviour
    {
        private AudioClip hello;
        private AudioClip grumpy;

        private AudioSource audioSource;

        void OnEnable()
        {
            // Load all sounds
            //sounds = (AudioClip[])Resources.LoadAll("Sounds", typeof(AudioClip));

            hello = Resources.Load<AudioClip>("Sounds/Hello");
            grumpy = Resources.Load<AudioClip>("Sounds/Grumpy");

            audioSource = gameObject.GetComponent<AudioSource>();
        }

        public void OnCharacterClick(CharacterClickResult ccr, int amount, Vector2 location)
        {
            AudioClip clipToPlay;

            switch (ccr)
            {
                case CharacterClickResult.HELLO:
                    clipToPlay = hello;
                    break;

                case CharacterClickResult.GRUMPY:
                    clipToPlay = grumpy;
                    break;

                default:
                    Debug.LogError("Why does enum not have a value?");
                    clipToPlay = hello;
                    break;
            }

            audioSource.PlayOneShot(clipToPlay);
        }

    }
}