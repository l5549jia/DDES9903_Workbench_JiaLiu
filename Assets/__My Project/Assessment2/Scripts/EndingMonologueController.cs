using System.Collections;
using UnityEngine;

public class EndingMonologueController : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip endingClip;

    [Header("Settings")]
    public float delay = 0f;

    private bool hasPlayed = false;

    public void PlayEnding()
    {
        if (hasPlayed)
        {
            return;
        }

        hasPlayed = true;

        StartCoroutine(EndingSequence());
    }

    private IEnumerator EndingSequence()
    {
        if (delay > 0f)
        {
            yield return new WaitForSeconds(delay);
        }

        if (audioSource == null || endingClip == null)
        {
            yield break;
        }

        audioSource.PlayOneShot(endingClip);
    }
}