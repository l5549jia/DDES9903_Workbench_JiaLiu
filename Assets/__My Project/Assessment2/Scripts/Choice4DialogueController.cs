using System.Collections;
using UnityEngine;

public class Choice4DialogueController : MonoBehaviour
{
    [Header("Dialogue")]
    public SpatialDialogueLinePlayer dialoguePlayer;

    [Header("References")]
    public GameObject choice04;
    public Choice3ReactionController choice3ReactionController;
    public FinalChoiceRouteController finalChoiceRouteController;

    [Header("Accept After Stay Audio")]
    public AudioClip acceptStayLine01;
    public AudioClip acceptStayLine02;

    [Header("Accept After Leave Audio")]
    public AudioClip acceptReturnLine01;
    public AudioClip acceptReturnLine02;

    [Header("Accept Shared Audio")]
    public AudioClip acceptSharedLine03;

    [Header("Reject After Stay Audio")]
    public AudioClip rejectStayLine01;
    public AudioClip rejectStayLine02;
    public AudioClip rejectStayLine03;

    [Header("Reject After Leave Audio")]
    public AudioClip rejectLeaveLine01;
    public AudioClip rejectLeaveLine02;

    [Header("State")]
    public bool choiceMade = false;
    public bool accepted = false;
    public bool rejected = false;

    public void ChooseAccept()
    {
        if (choiceMade)
        {
            return;
        }

        choiceMade = true;
        accepted = true;

        if (choice04 != null)
        {
            choice04.SetActive(false);
        }

        StartCoroutine(AcceptSequence());
    }

    public void ChooseReject()
    {
        if (choiceMade)
        {
            return;
        }

        choiceMade = true;
        rejected = true;

        if (choice04 != null)
        {
            choice04.SetActive(false);
        }

        StartCoroutine(RejectSequence());
    }

    private IEnumerator AcceptSequence()
    {
        if (dialoguePlayer == null)
        {
            CompleteAccept();
            yield break;
        }

        if (choice3ReactionController != null &&
            choice3ReactionController.stayedAndListened)
        {
            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "You stayed.",
                    acceptStayLine01
                )
            );

            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "That's enough for now.",
                    acceptStayLine02
                )
            );
        }
        else if (choice3ReactionController != null &&
                 choice3ReactionController.triedToLeave)
        {
            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "You came back.",
                    acceptReturnLine01
                )
            );

            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "That's enough for now.",
                    acceptReturnLine02
                )
            );
        }

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Let's go.",
                acceptSharedLine03
            )
        );

        CompleteAccept();
    }

    private IEnumerator RejectSequence()
    {
        if (dialoguePlayer == null)
        {
            CompleteReject();
            yield break;
        }

        if (choice3ReactionController != null &&
            choice3ReactionController.stayedAndListened)
        {
            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "You listened.",
                    rejectStayLine01
                )
            );

            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "But you still chose to leave me here.",
                    rejectStayLine02
                )
            );

            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "I'll wait.",
                    rejectStayLine03
                )
            );
        }
        else if (choice3ReactionController != null &&
                 choice3ReactionController.triedToLeave)
        {
            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "Of course.",
                    rejectLeaveLine01
                )
            );

            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "I'll wait.",
                    rejectLeaveLine02
                )
            );
        }

        CompleteReject();
    }

    private void CompleteAccept()
    {
        if (finalChoiceRouteController != null)
        {
            finalChoiceRouteController.ChooseAccept();
        }
    }

    private void CompleteReject()
    {
        if (finalChoiceRouteController != null)
        {
            finalChoiceRouteController.ChooseReject();
        }
    }
}