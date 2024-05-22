using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsound : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    CapsuleCollider capsuleCollider;

    private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        if (audioSource != null)
        {
            audioClip = audioSource.clip;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("NPC sound is on! (entered)");
        PlaySound();
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("NPC sound is not on (exited)");
    }

    // Plays the sound clip
    void PlaySound()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
