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
        private AudioSource audioSource;
       // private AudioClip audioClip;
        bool started = false;

        public void AssignProperties(AudioClip clip, float volume)
        {

            audioSource = this.gameObject.AddComponent<AudioSource>();
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
                Destroy(audioSource);
                Destroy(this.gameObject);
            }
            
        }
    }
}
