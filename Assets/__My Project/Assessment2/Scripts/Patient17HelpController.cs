using System.Collections;
using UnityEngine;

public class Patient17HelpController : MonoBehaviour
{
    [Header("Dialogue")]
    public SpatialDialogueLinePlayer dialoguePlayer;

    [Header("Help Audio")]
    public AudioClip helpLine01;
    public AudioClip helpLine02;
    public AudioClip helpLine03;
    public AudioClip helpLine04;
    public AudioClip helpLine05;

    [Header("Choice")]
    public GameObject choice02;

    [Header("State")]
    public bool sequenceStarted = false;
    public bool sequenceFinished = false;

    private void Start()
    {
        if (choice02 != null)
        {
            choice02.SetActive(false);
        }
    }

    public void StartHelpSequence()
    {
        if (sequenceStarted)
        {
            return;
        }

        sequenceStarted = true;

        StartCoroutine(HelpSequence());
    }

    private IEnumerator HelpSequence()
    {
        if (dialoguePlayer == null)
        {
            yield break;
        }

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Hey... can you hear me?",
                helpLine01
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "The door's locked.",
                helpLine02
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "I can't open it from this side.",
                helpLine03
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Could you help me get out?",
                helpLine04
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "There might be something in the doctor's office or the nurse lounge.",
                helpLine05
            )
        );

        sequenceFinished = true;

        if (choice02 != null)
        {
            choice02.SetActive(true);
        }

        Debug.Log("CHOICE 02: Doctor's Office or Nurse Lounge.");
    }
}