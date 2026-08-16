using System.Collections;
using UnityEngine;

public class Choice3ReactionController : MonoBehaviour
{
    [Header("Dialogue")]
    public SpatialDialogueLinePlayer dialoguePlayer;

    [Header("References")]
    public GameObject choice03;
    public GameObject choice04;
    public Choice2BranchController choice2Controller;

    [Header("Leave Route")]
    public GameObject leaveAttemptTrigger;
    public GameObject roomExitBlocker;

    [Header("Stay Audio")]
    public AudioClip stayLine01;
    public AudioClip stayLine02;
    public AudioClip stayLine03;
    public AudioClip stayLine04;

    [Header("Doctor Evidence Audio")]
    public AudioClip doctorLine01;
    public AudioClip doctorLine02;
    public AudioClip doctorLine03;

    [Header("Nurse Evidence Audio")]
    public AudioClip nurseLine01;
    public AudioClip nurseLine02;
    public AudioClip nurseLine03;

    [Header("Leave Audio")]
    public AudioClip leaveLine01;
    public AudioClip leaveLine02;
    public AudioClip leaveLine03;
    public AudioClip leaveLine04;
    public AudioClip leaveLine05;
    public AudioClip leaveLine06;
    public AudioClip leaveLine07;
    public AudioClip leaveLine08;
    public AudioClip leaveLine09;

    [Header("Reveal Audio")]
    public AudioClip revealLine01;
    public AudioClip revealLine02;
    public AudioClip revealLine03;
    public AudioClip revealLine04;
    public AudioClip revealLine05;

    [Header("State")]
    public bool choiceMade = false;
    public bool stayedAndListened = false;
    public bool triedToLeave = false;
    public bool identityRevealed = false;

    private void Start()
    {
        if (choice04 != null)
        {
            choice04.SetActive(false);
        }

        if (leaveAttemptTrigger != null)
        {
            leaveAttemptTrigger.SetActive(false);
        }

        if (roomExitBlocker != null)
        {
            roomExitBlocker.SetActive(false);
        }
    }

    public void StayAndListen()
    {
        if (choiceMade)
        {
            return;
        }

        choiceMade = true;
        stayedAndListened = true;

        if (choice03 != null)
        {
            choice03.SetActive(false);
        }

        if (roomExitBlocker != null)
        {
            roomExitBlocker.SetActive(true);
        }

        StartCoroutine(StaySequence());
    }

    public void TryToLeave()
    {
        if (choiceMade)
        {
            return;
        }

        choiceMade = true;
        triedToLeave = true;

        if (choice03 != null)
        {
            choice03.SetActive(false);
        }

        if (roomExitBlocker != null)
        {
            roomExitBlocker.SetActive(true);
        }

        if (leaveAttemptTrigger != null)
        {
            leaveAttemptTrigger.SetActive(true);
        }

        StartCoroutine(LeaveOpeningSequence());
    }

    private IEnumerator LeaveOpeningSequence()
    {
        if (dialoguePlayer == null)
        {
            yield break;
        }

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Okay.",
                leaveLine01
            )
        );

        Debug.Log("LEAVE ROUTE: Walk toward the room exit.");
    }

    private IEnumerator StaySequence()
    {
        if (dialoguePlayer == null)
        {
            yield break;
        }

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "You stayed.",
                stayLine01
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "That's different.",
                stayLine02
            )
        );

        yield return StartCoroutine(
            PlayEvidenceMemory()
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Maybe leaving was never the problem.",
                stayLine03
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Maybe it was what you were trying to leave behind.",
                stayLine04
            )
        );

        yield return StartCoroutine(
            RevealIdentity()
        );
    }

    public void TriggerLeaveConfrontation()
    {
        if (!triedToLeave)
        {
            return;
        }

        if (identityRevealed)
        {
            return;
        }

        if (leaveAttemptTrigger != null)
        {
            leaveAttemptTrigger.SetActive(false);
        }

        StartCoroutine(LeaveSequence());
    }

    private IEnumerator LeaveSequence()
    {
        if (dialoguePlayer == null)
        {
            yield break;
        }

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "There it is.",
                leaveLine02
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "You always do that.",
                leaveLine03
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "The moment something gets difficult, you leave.",
                leaveLine04
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "The job.",
                leaveLine05
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "The people.",
                leaveLine06
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "The memories.",
                leaveLine07
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "Me.",
                leaveLine08
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "And you still don't understand why you can't get out.",
                leaveLine09
            )
        );

        yield return StartCoroutine(
            PlayEvidenceMemory()
        );

        yield return StartCoroutine(
            RevealIdentity()
        );
    }

    private IEnumerator PlayEvidenceMemory()
    {
        if (dialoguePlayer == null)
        {
            yield break;
        }

        if (choice2Controller == null)
        {
            yield break;
        }

        if (choice2Controller.choseDoctorOffice)
        {
            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "You saw the record.",
                    doctorLine01
                )
            );

            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "Incomplete.",
                    doctorLine02
                )
            );

            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "And yet they told you that you were ready to leave.",
                    doctorLine03
                )
            );
        }
        else if (choice2Controller.choseNurseLounge)
        {
            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "You saw what they wrote.",
                    nurseLine01
                )
            );

            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "Asking to leave.",
                    nurseLine02
                )
            );

            yield return StartCoroutine(
                dialoguePlayer.PlayLine(
                    "You've been asking too, haven't you?",
                    nurseLine03
                )
            );
        }
    }

    private IEnumerator RevealIdentity()
    {
        if (identityRevealed)
        {
            yield break;
        }

        identityRevealed = true;

        if (dialoguePlayer == null)
        {
            yield break;
        }

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "There's something they didn't tell you.",
                revealLine01
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "There aren't two Patient 17s.",
                revealLine02
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "There never were.",
                revealLine03
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "I'm the part of you that you keep trying to leave behind.",
                revealLine04
            )
        );

        yield return StartCoroutine(
            dialoguePlayer.PlayLine(
                "So... are you still going to leave me here?",
                revealLine05
            )
        );

        if (choice04 != null)
        {
            choice04.SetActive(true);
        }

        Debug.Log("CHOICE 04: Final choice is now available.");
    }
}