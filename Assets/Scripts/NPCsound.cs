using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource), typeof(CapsuleCollider))]
public class NPCsound : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    CapsuleCollider capsuleCollider;

    private AudioClip audioClip;

    [SerializeField]
    private float soundCooldown = 1.0f; // in seconds.

    private bool soundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        // check
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (!capsuleCollider)
        {
            capsuleCollider = GetComponent<CapsuleCollider>();
        }

        if (audioSource != null)
        {
            audioClip = audioSource.clip;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("NPC sound is on! (entered)");
        if (!soundPlayed)
        {
            PlaySound();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Debug.Log("NPC sound is not on (exited)");

    }

    // play sound here
    void PlaySound()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
            soundPlayed = true;
            StartCoroutine(SoundCooldownCoroutine());
        }
        else
        {
            Debug.LogError("Error: you need to insert the audio part");
        }
    }

    private IEnumerator SoundCooldownCoroutine()
    {
        yield return new WaitForSeconds(soundCooldown);
        soundPlayed = false;
    }
}
