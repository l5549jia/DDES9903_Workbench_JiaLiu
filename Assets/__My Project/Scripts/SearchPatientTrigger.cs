using UnityEngine;

public class SearchPatientTrigger : MonoBehaviour
{
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

        hasTriggered = true;

        StoryManager.Instance.ReachPatient17Room();
    }
}