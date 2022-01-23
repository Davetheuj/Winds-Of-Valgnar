using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameObjects
{
    class TemporaryAudioSource : MonoBehaviour
    {
        private AudioSource audioSource = new AudioSource();
       // private AudioClip audioClip;
        bool started = false;

        public TemporaryAudioSource(AudioClip clip, float volume )
        {
  
            audioSource.clip = clip;
            audioSource.volume = volume;

            audioSource.Play();
            started = true;
        }

        void Start()
        {
            
        }

        void Update()
        {
            if(started && !audioSource.isPlaying)
            {
                Destroy(this);
            }
            
        }
    }
}
