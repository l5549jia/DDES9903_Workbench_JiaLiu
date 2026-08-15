using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choice3EndingController : MonoBehaviour
{
    [Header("References")]
    public GameObject choice03;
    public GameObject patient17;
    public GameObject patient17Outline;

    [Header("Accept Ending")]
    public GameObject exitDoor;
    public GameObject dischargeClearedDisplay;

    [Header("Ending State")]
    public bool endingChosen = false;
    public bool acceptedPatient17 = false;
    public bool rejectedPatient17 = false;

    public void AcceptPatient17()
    {
        if (endingChosen)
        {
            return;
        }

        endingChosen = true;
        acceptedPatient17 = true;

        if (choice03 != null)
        {
            choice03.SetActive(false);
        }

        StartCoroutine(AcceptEndingSequence());
    }

    public void RejectPatient17()
    {
        if (endingChosen)
        {
            return;
        }

        endingChosen = true;
        rejectedPatient17 = true;

        if (choice03 != null)
        {
            choice03.SetActive(false);
        }

        StartCoroutine(RejectEndingSequence());
    }

    private IEnumerator AcceptEndingSequence()
    {
        Debug.Log("PATIENT 17: You don't have to fix me.");
        yield return new WaitForSeconds(2f);

        Debug.Log("PATIENT 17: Just don't leave me behind.");
        yield return new WaitForSeconds(3f);

        if (patient17Outline != null)
        {
            patient17Outline.SetActive(false);
        }

        if (patient17 != null)
        {
            patient17.SetActive(false);
        }

        if (dischargeClearedDisplay != null)
        {
            dischargeClearedDisplay.SetActive(true);
        }

        if (exitDoor != null)
        {
            exitDoor.SetActive(false);
        }

        Debug.Log("ENDING: Patient 17 has been accepted.");
        Debug.Log("DISCHARGE STATUS: CLEARED.");
        Debug.Log("EXIT: The hospital exit is now open.");
    }

    private IEnumerator RejectEndingSequence()
    {
        Debug.Log("PATIENT 17: Okay.");
        yield return new WaitForSeconds(2f);

        Debug.Log("PATIENT 17: I'll wait.");
        yield return new WaitForSeconds(3f);

        Debug.Log("NURSE: Patient 17, your discharge is ready.");
        yield return new WaitForSeconds(2f);

        Debug.Log("NURSE: But there is one last thing.");
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}