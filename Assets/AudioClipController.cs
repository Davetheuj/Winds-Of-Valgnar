using Assets.GameObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioClipController : MonoBehaviour
{
    [Tooltip("This is set on Start()")]
    public AudioSource audioSource;

    public List<AudioClip> ambientClips = new List<AudioClip>();
    public List<AudioClip> interactionClips = new List<AudioClip>();
    public List<AudioClip> deinteractionClips = new List<AudioClip>();

    private List<StackableAudioClip> clipStack = new List<StackableAudioClip>();
    private float defaultVolume;
    private float shouldLoop;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //first try to set the audioSource to the one that is attached to the same component as the clip controller
        try
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }
        //if this doesnt work we'll look for an audioSource in the gameobject's children
        catch (Exception e)
        {
            Debug.Log($"Could not find audio source on {gameObject.name}...checking children. ({e.GetType()})");
            try
            {
                audioSource = gameObject.GetComponentInChildren<AudioSource>();
            }
            catch (Exception e2)
            {
                Debug.Log($"Could not find audio source on {gameObject.name}'s children, clips will not be played from this object. ({e2.GetType()})");
            }
        }
        //Break out of start() if there's no audio source, we don't have to go any further.
        if (audioSource == null)
        {
            //disable this controller
            this.enabled = false;
            return;
        }
        defaultVolume = audioSource.volume;
    }

    public void PlayAmbientClip(int clipIndex = -1, float volume = -1, bool loop = false, int priority = -5000, bool stack = false, bool createTemporarySource = false)
    {
        if(ambientClips.Count == 0)
        if(clipIndex <= 0)
        {
            clipIndex = new System.Random().Next(0, ambientClips.Count - 1);
        }
        if(volume < 0)
        {
            volume = defaultVolume;
        }
        if (createTemporarySource)
        {
            TemporaryAudioSource tempSource = this.gameObject.AddComponent<TemporaryAudioSource>();
            //Assigning the properties will start the source, it's lifespan is dependent on the mediaDuration of the clip, after which time it will be destroyed
            tempSource.AssignProperties(ambientClips[clipIndex], volume);
            return;   
        }
        if (stack)
        {
            AddClipToStack(new StackableAudioClip(ambientClips[clipIndex], priority, volume));
            return;
        }

        audioSource.clip = ambientClips[clipIndex];
        audioSource.volume = volume;
        audioSource.loop = loop;
        audioSource.Play();
        
    }



    

    private void Update()
    {
        
    }

    private void AddClipToStack(StackableAudioClip clip)
    {
        clipStack.Add(clip);
        clipStack = clipStack.OrderBy(o => o.priority).ToList();

    }


}
