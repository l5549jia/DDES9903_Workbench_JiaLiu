using UnityEngine;

public class FinalDoorDestinationTrigger : MonoBehaviour
{
    [Header("References")]
    public FinalChoiceRouteController finalChoiceController;

    [Header("Destinations")]
    public Transform trueEndingSpawn;
    public Transform loopEndingSpawn;

    [Header("Ending Areas")]
    public GameObject trueEndingArea;
    public GameObject loopEndingArea;

    [Header("Ending Monologues")]
    public EndingMonologueController trueEndingMonologue;
    public EndingMonologueController loopEndingMonologue;

    private bool hasTriggered = false;

    private void Start()
    {
        if (trueEndingArea != null)
        {
            trueEndingArea.SetActive(false);
        }

        if (loopEndingArea != null)
        {
            loopEndingArea.SetActive(false);
        }
    }

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

        if (finalChoiceController == null)
        {
            return;
        }

        if (finalChoiceController.acceptedPatient17)
        {
            hasTriggered = true;

            if (trueEndingArea != null)
            {
                trueEndingArea.SetActive(true);
            }

            TeleportPlayer(
                other.gameObject,
                trueEndingSpawn
            );

            if (trueEndingMonologue != null)
            {
                trueEndingMonologue.PlayEnding();
            }

            Debug.Log(
                "ENDING ROUTE: Player entered the true ending."
            );
        }
        else if (finalChoiceController.rejectedPatient17)
        {
            hasTriggered = true;

            if (loopEndingArea != null)
            {
                loopEndingArea.SetActive(true);
            }

            TeleportPlayer(
                other.gameObject,
                loopEndingSpawn
            );

            if (loopEndingMonologue != null)
            {
                loopEndingMonologue.PlayEnding();
            }

            Debug.Log(
                "ENDING ROUTE: Player entered the loop ending."
            );
        }
    }

    private void TeleportPlayer(
        GameObject player,
        Transform destination
    )
    {
        if (player == null || destination == null)
        {
            return;
        }

        CharacterController characterController =
            player.GetComponent<CharacterController>();

        if (characterController != null)
        {
            characterController.enabled = false;
        }

        player.transform.position = destination.position;
        player.transform.rotation = destination.rotation;

        if (characterController != null)
        {
            characterController.enabled = true;
        }
    }
}