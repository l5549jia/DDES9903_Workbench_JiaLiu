using System.Collections;
using UnityEngine;

public class NurseOpeningDialogueController : MonoBehaviour
{
    [Header("Dialogue")]
    public SpatialDialogueLinePlayer dialoguePlayer;

    [Header("Opening Audio")]
    public AudioClip openingLine01;
    public AudioClip openingLine02;
    public AudioClip openingLine03;

    [Header("Who Is Waiting Audio")]
    public AudioClip whoLine01;
    public AudioClip whoLine02;

    [Header("Discharge Audio")]
    public AudioClip dischargeLine01;
    public AudioClip dischargeLine02;

    [Header("Scene References")]
    public GameObject nurse;
    public GameObject patient17;
    public GameObject choice01;

    [Header("Opening Doors")]
    public GameObject door01Closed;
    public GameObject door01Open;
    public GameObject door02Closed;
    public GameObject door02Open;

    [Header("State")]
    public bool sequenceStarted = false;
    public bool choiceMade = false;

    private void Start()
    {
        if (choice01 != null)
        {
            choice01.SetActive(false);
        }
    }

    public void StartOpeningSequence()
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

        if (StoryManager.Instance != null)
        {
            StoryManager.Instance.openingStarted = true;
        }

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Patient 17, your discharge is ready.",
                openingLine01
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "But there is one last thing.",
                openingLine02
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Someone is waiting for you in the last room down the corridor.",
                openingLine03
            )
        );

        if (StoryManager.Instance != null)
        {
            StoryManager.Instance.openingFinished = true;
            StoryManager.Instance.openingChoiceShown = true;
        }

        if (choice01 != null)
        {
            choice01.SetActive(true);
        }

        Debug.Log("CHOICE 01: Opening choice is now available.");
    }

    public void AskWhoIsWaiting()
    {
        if (choiceMade)
        {
            return;
        }

        choiceMade = true;

        if (choice01 != null)
        {
            choice01.SetActive(false);
        }

        if (StoryManager.Instance != null)
        {
            StoryManager.Instance.openingChoiceResolved = true;
            StoryManager.Instance.askedWhoIsWaiting = true;
            StoryManager.Instance.askedAboutDischarge = false;
        }

        StartCoroutine(WhoResponseSequence());
    }

    private IEnumerator WhoResponseSequence()
    {
        if (dialoguePlayer == null)
        {
            FinishOpening();
            yield break;
        }

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "You'll understand when you see him.",
                whoLine01
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "He's waiting in the last room.",
                whoLine02
            )
        );

        FinishOpening();
    }

    public void AskAboutDischarge()
    {
        if (choiceMade)
        {
            return;
        }

        choiceMade = true;

        if (choice01 != null)
        {
            choice01.SetActive(false);
        }

        if (StoryManager.Instance != null)
        {
            StoryManager.Instance.openingChoiceResolved = true;
            StoryManager.Instance.askedWhoIsWaiting = false;
            StoryManager.Instance.askedAboutDischarge = true;
        }

        StartCoroutine(DischargeResponseSequence());
    }

    private IEnumerator DischargeResponseSequence()
    {
        if (dialoguePlayer == null)
        {
            FinishOpening();
            yield break;
        }

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Your paperwork is complete.",
                dischargeLine01
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "The remaining problem isn't paperwork.",
                dischargeLine02
            )
        );

        FinishOpening();
    }

    private void FinishOpening()
    {
        if (door01Closed != null)
        {
            door01Closed.SetActive(false);
        }

        if (door01Open != null)
        {
            door01Open.SetActive(true);
        }

        if (door02Closed != null)
        {
            door02Closed.SetActive(false);
        }

        if (door02Open != null)
        {
            door02Open.SetActive(true);
        }

        if (patient17 != null)
        {
            patient17.SetActive(true);
        }

        if (StoryManager.Instance != null)
        {
            StoryManager.Instance.openingComplete = true;
        }

        Debug.Log("OPENING COMPLETE: Doors are open and Patient 17 is active.");

        if (nurse != null)
        {
            nurse.SetActive(false);
        }
    }
}