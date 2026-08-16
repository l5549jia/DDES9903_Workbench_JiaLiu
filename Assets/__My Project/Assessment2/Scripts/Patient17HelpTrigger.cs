using UnityEngine;

public class Patient17HelpTrigger : MonoBehaviour
{
    [Header("References")]
    public Patient17HelpController helpController;

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

        if (StoryManager.Instance == null)
        {
            return;
        }

        if (!StoryManager.Instance.openingComplete)
        {
            return;
        }

        if (helpController == null)
        {
            return;
        }

        hasTriggered = true;

        helpController.StartHelpSequence();
    }
}