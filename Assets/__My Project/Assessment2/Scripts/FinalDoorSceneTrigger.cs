using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoorSceneTrigger : MonoBehaviour
{
    [Header("References")]
    public FinalChoiceRouteController finalChoiceController;

    [Header("Ending Scenes")]
    public string trueEndingScene = "Ending_TrueCourtyard";
    public string loopEndingScene = "Ending_LoopRoom";

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

        if (finalChoiceController == null)
        {
            return;
        }

        hasTriggered = true;

        if (finalChoiceController.acceptedPatient17)
        {
            Debug.Log("ENDING ROUTE: Loading true ending.");

            SceneManager.LoadScene(trueEndingScene);
        }
        else if (finalChoiceController.rejectedPatient17)
        {
            Debug.Log("ENDING ROUTE: Loading loop ending.");

            SceneManager.LoadScene(loopEndingScene);
        }
    }
}