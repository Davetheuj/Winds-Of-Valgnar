using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.GameObjects
{
    class TemporaryAudioSource : MonoBehaviour
    {
        private AudioSource audioSource;
        bool started = false;

        public void AssignProperties(AudioClip clip, float volume, AudioMixer audioMixer, string mixerGroup)
        {
            audioSource = this.gameObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups(mixerGroup)[0];
            

            audioSource.Play();
            started = true;
        }

        void Update()
        {
            if(started && !audioSource.isPlaying)
            {
                //Destroy(audioSource);
                
                Destroy(this.gameObject);
            }
            
        }
    }
}
