using System.Collections;
using UnityEngine;

public class Patient17StoryController : MonoBehaviour
{
    public Choice2BranchController choice2Controller;

    public GameObject choice03;

    private bool started = false;


    public void StartPatient17Sequence()
    {
        if (started)
            return;

        started = true;

        StartCoroutine(Patient17Sequence());
    }


    private IEnumerator Patient17Sequence()
    {
        Debug.Log("PATIENT 17: So you found a way in.");

        yield return new WaitForSeconds(2f);


        Debug.Log("PATIENT 17: Did they tell you that you're ready to leave?");

        yield return new WaitForSeconds(3f);


        Debug.Log("PATIENT 17: They told me the same thing.");

        yield return new WaitForSeconds(3f);


        PlayBranchMemory();


        yield return new WaitForSeconds(5f);


        Debug.Log("PATIENT 17: There is something they didn't tell you.");

        yield return new WaitForSeconds(3f);


        Debug.Log("PATIENT 17: There aren't two Patient 17s.");

        yield return new WaitForSeconds(3f);


        Debug.Log("PATIENT 17: There never were.");

        yield return new WaitForSeconds(4f);


        Debug.Log("PATIENT 17: I'm the part of you that you keep trying to leave behind.");


        yield return new WaitForSeconds(5f);


        Debug.Log("PATIENT 17: Are you still going to leave me here?");


        if (choice03 != null)
        {
            choice03.SetActive(true);
        }
    }



    private void PlayBranchMemory()
    {
        if (choice2Controller == null)
            return;


        if (choice2Controller.choseDoctorOffice)
        {
            Debug.Log("PATIENT 17: You saw the record.");

            Debug.Log("PATIENT 17: DISCHARGE STATUS: INCOMPLETE.");

            Debug.Log("PATIENT 17: But they told you that you were ready.");
        }


        else if (choice2Controller.choseNurseLounge)
        {
            Debug.Log("PATIENT 17: You saw what they wrote.");

            Debug.Log("PATIENT 17: Keeps asking to leave.");

            Debug.Log("PATIENT 17: You've been asking too, haven't you?");
        }
    }
}