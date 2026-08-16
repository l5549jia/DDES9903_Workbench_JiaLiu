using UnityEngine;

public class NurseOpeningTrigger : MonoBehaviour
{
    [Header("References")]
    public NurseOpeningDialogueController openingController;

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

        if (openingController == null)
        {
            return;
        }

        hasTriggered = true;

        openingController.StartOpeningSequence();
    }
}