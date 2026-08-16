using System.Collections;
using UnityEngine;

public class PlayerRoomMonologueController : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Monologue Audio")]
    public AudioClip openClip;
    public AudioClip bedClip;
    public AudioClip tableClip;
    public AudioClip tvClip;

    [Header("Opening")]
    public float openingDelay = 1f;

    private bool openingInProgress = false;
    private bool bedPlayed = false;
    private bool tablePlayed = false;
    private bool tvPlayed = false;

    private void Start()
    {
        StartCoroutine(OpeningSequence());
    }

    private IEnumerator OpeningSequence()
    {
        openingInProgress = true;

        yield return new WaitForSeconds(openingDelay);

        if (audioSource != null && openClip != null)
        {
            audioSource.PlayOneShot(openClip);

            while (audioSource.isPlaying)
            {
                yield return null;
            }
        }

        openingInProgress = false;
    }

    public void PlayBed()
    {
        if (openingInProgress || bedPlayed)
        {
            return;
        }

        if (audioSource != null && audioSource.isPlaying)
        {
            return;
        }

        if (bedClip == null)
        {
            return;
        }

        bedPlayed = true;
        audioSource.PlayOneShot(bedClip);
    }

    public void PlayTable()
    {
        if (openingInProgress || tablePlayed)
        {
            return;
        }

        if (audioSource != null && audioSource.isPlaying)
        {
            return;
        }

        if (tableClip == null)
        {
            return;
        }

        tablePlayed = true;
        audioSource.PlayOneShot(tableClip);
    }

    public void PlayTV()
    {
        if (openingInProgress || tvPlayed)
        {
            return;
        }

        if (audioSource != null && audioSource.isPlaying)
        {
            return;
        }

        if (tvClip == null)
        {
            return;
        }

        tvPlayed = true;
        audioSource.PlayOneShot(tvClip);
    }
}