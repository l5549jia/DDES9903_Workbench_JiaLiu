using UnityEngine;

public class FinalChoiceRouteController : MonoBehaviour
{
    [Header("Choice")]
    public GameObject choice04;

    [Header("Patient 17")]
    public GameObject patient17;
    public GameObject patient17Outline;

    [Header("Final Path")]
    public GameObject finalWall;
    public GameObject finalDoor;
    public GameObject roomExitBlocker;

    [Header("Final Choice State")]
    public bool acceptedPatient17 = false;
    public bool rejectedPatient17 = false;

    private bool choiceMade = false;

    public void ChooseAccept()
    {
        if (choiceMade)
        {
            return;
        }

        choiceMade = true;

        acceptedPatient17 = true;
        rejectedPatient17 = false;

        Debug.Log("FINAL CHOICE: Player accepted Patient 17.");

        OpenFinalPath();
    }

    public void ChooseReject()
    {
        if (choiceMade)
        {
            return;
        }

        choiceMade = true;

        acceptedPatient17 = false;
        rejectedPatient17 = true;

        Debug.Log("FINAL CHOICE: Player rejected Patient 17.");

        OpenFinalPath();
    }

    private void OpenFinalPath()
    {
        if (choice04 != null)
        {
            choice04.SetActive(false);
        }

        if (patient17Outline != null)
        {
            patient17Outline.SetActive(false);
        }

        if (patient17 != null)
        {
            patient17.SetActive(false);
        }

        if (roomExitBlocker != null)
        {
            roomExitBlocker.SetActive(false);
        }

        if (finalWall != null)
        {
            finalWall.SetActive(false);
        }

        if (finalDoor != null)
        {
            finalDoor.SetActive(true);
        }

        Debug.Log("FINAL PATH: Patient 17 is hidden and the final door is available.");
    }
}