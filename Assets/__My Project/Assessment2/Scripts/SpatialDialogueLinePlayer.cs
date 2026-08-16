using System.Collections;
using TMPro;
using UnityEngine;

public class SpatialDialogueLinePlayer : MonoBehaviour
{
    [Header("Speaker")]
    public string speakerName;

    [Header("Subtitle")]
    public TMP_Text subtitleText;

    [Header("Audio")]
    public AudioSource audioSource;

    [Header("Fallback Timing")]
    public float minimumDisplayTime = 2f;
    public float charactersPerSecond = 15f;

    [Header("Subtitle Timing")]
    public float extraDisplayTime = 0.15f;

    private void Start()
    {
        if (subtitleText != null)
        {
            subtitleText.text = "";
        }
    }

    public IEnumerator PlayLine(string subtitle, AudioClip clip)
    {
        if (subtitleText != null)
        {
            subtitleText.text = subtitle;
        }

        if (!string.IsNullOrEmpty(speakerName))
        {
            Debug.Log(speakerName + ": " + subtitle);
        }

        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);

            yield return new WaitForSeconds(
                clip.length + extraDisplayTime
            );
        }
        else
        {
            float fallbackTime = Mathf.Max(
                minimumDisplayTime,
                subtitle.Length / charactersPerSecond
            );

            yield return new WaitForSeconds(fallbackTime);
        }

        if (subtitleText != null)
        {
            subtitleText.text = "";
        }
    }
}