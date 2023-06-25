using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSoundPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;

    private AudioSource audioSource;
    private bool isPlaying = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandom()
    {
        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }

    public void PlayContinous()
    {
        isPlaying = true;
    }

    public void StopContnousPlaying()
    {
        isPlaying = false;
        audioSource.Stop();
    }

    private void Update()
    {
        if(isPlaying)
        {
            if(!audioSource.isPlaying)
            {
                PlayRandom();
            }
        }
    }
}
