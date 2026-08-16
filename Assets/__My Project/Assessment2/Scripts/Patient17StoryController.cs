using System.Collections;
using UnityEngine;

public class Patient17StoryController : MonoBehaviour
{
    [Header("Dialogue")]
    public SpatialDialogueLinePlayer dialoguePlayer;

    [Header("Opening Audio")]
    public AudioClip openingLine01;
    public AudioClip openingLine02;
    public AudioClip openingLine03;
    public AudioClip openingLine04;
    public AudioClip openingLine05;

    [Header("Choice")]
    public GameObject choice03;

    [Header("State")]
    public bool sequenceStarted = false;
    public bool openingFinished = false;

    private void Start()
    {
        if (choice03 != null)
        {
            choice03.SetActive(false);
        }
    }

    public void StartPatient17Sequence()
    {
        if (sequenceStarted)
        {
            return;
        }

        sequenceStarted = true;

        StartCoroutine(OpeningSequence());
    }

    private IEnumerator OpeningSequence()
    {
        if (dialoguePlayer == null)
        {
            yield break;
        }

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "So you found a way in.",
                openingLine01
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Did they tell you that you're ready to leave?",
                openingLine02
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "They told me the same thing.",
                openingLine03
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Before you go...",
                openingLine04
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Do you want to know what they didn't tell you?",
                openingLine05
            )
        );

        openingFinished = true;

        ShowChoice03();
    }

    private void ShowChoice03()
    {
        if (choice03 != null)
        {
            choice03.SetActive(true);
        }

        Debug.Log("CHOICE 03: Stay and listen, or leave.");
    }
}