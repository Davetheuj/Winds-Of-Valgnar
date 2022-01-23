using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameObjects
{
    class StackableAudioClip
    {
        AudioClip clip;
        int priority;
        public StackableAudioClip(AudioClip clip, int priority)
        {
            this.clip = clip;
            this.priority = priority;

        }
    }
}
