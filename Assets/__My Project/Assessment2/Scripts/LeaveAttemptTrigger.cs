using UnityEngine;

public class LeaveAttemptTrigger : MonoBehaviour
{
    public Choice3ReactionController reactionController;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered)
        {
            return;
        }

        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (reactionController == null)
        {
            return;
        }

        hasTriggered = true;

        reactionController.TriggerLeaveConfrontation();
    }
}