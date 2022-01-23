using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameObjects
{
    //This class is used with AudioClipControllers
    class StackableAudioClip
    {
        AudioClip clip;
        int priority;
        float volume;
        public StackableAudioClip(AudioClip clip, int priority, float volume)
        {
            this.clip = clip;
            this.priority = priority;
            this.volume = volume;

        }
    }
}
