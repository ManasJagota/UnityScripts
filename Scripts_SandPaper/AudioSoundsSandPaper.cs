using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSoundsSandPaper : MonoBehaviour
{

    /*1. clip 1 for tile click
      2. clip 2 for coin click sound
      3. clip for button clicks
      4. clip for well played text pop up
      5. clip for wrong tile click
    */ 

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayAudioOnce(int index)
    {
        audioSource.Pause();
        audioSource.PlayOneShot(audioClips[index]);
    }

    
}
