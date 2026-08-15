using UnityEngine;
using UnityEngine.Events;

public class PlayerOneShotTrigger : MonoBehaviour
{
    [Header("Trigger Event")]
    public UnityEvent onTriggered;

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

        hasTriggered = true;

        Debug.Log("T03: Player entered Patient 17 room.");

        onTriggered?.Invoke();
    }
}