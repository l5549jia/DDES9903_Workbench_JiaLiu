using System.Collections;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance { get; private set; }

    [Header("Opening")]
    public GameObject nurse;
    public AudioSource nurseAudioSource;
    public AudioClip openingClip;

    [Header("Nurse Choice Responses")]
    public AudioClip whoIsWaitingClip;
    public AudioClip dischargeProblemClip;

    [Header("Patient 17")]
    public GameObject patient17;
    public AudioSource patient17AudioSource;
    public AudioClip lockedRoomClip;

    [Header("Opening Doors")]
    public GameObject door01Closed;
    public GameObject door01Open;
    public GameObject door02Closed;
    public GameObject door02Open;

    [Header("Branch Doors")]
    public GameObject doctorOfficeDoor;
    public GameObject nurseLoungeDoor;

    [Header("Choices")]
    public GameObject choice01;
    public GameObject choice02;

    [Header("Opening State")]
    public bool openingStarted = false;
    public bool openingFinished = false;
    public bool openingChoiceShown = false;
    public bool openingChoiceResolved = false;
    public bool openingComplete = false;

    [Header("Opening Choice Result")]
    public bool askedWhoIsWaiting = false;
    public bool askedAboutDischarge = false;

    [Header("Patient 17 Room State")]
    public bool reachedPatient17Room = false;
    public bool patient17RoomChoiceShown = false;
    public bool patient17RoomChoiceResolved = false;

    [Header("Branch State")]
    public bool choseDoctorOffice = false;
    public bool choseNurseLounge = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        if (patient17 != null)
        {
            patient17.SetActive(false);
        }

        if (choice01 != null)
        {
            choice01.SetActive(false);
        }

        if (choice02 != null)
        {
            choice02.SetActive(false);
        }

        if (doctorOfficeDoor != null)
        {
            doctorOfficeDoor.SetActive(true);
        }

        if (nurseLoungeDoor != null)
        {
            nurseLoungeDoor.SetActive(true);
        }

        SetOpeningDoors(false);
    }

    public void StartOpening()
    {
        if (openingStarted)
        {
            return;
        }

        StartCoroutine(OpeningSequence());
    }

    private IEnumerator OpeningSequence()
    {
        openingStarted = true;

        Debug.Log("NURSE: Patient 17, your discharge is ready.");
        Debug.Log("NURSE: But there is one last thing.");
        Debug.Log("NURSE: Someone is waiting for you in the last room down the corridor.");

        if (nurseAudioSource != null && openingClip != null)
        {
            nurseAudioSource.PlayOneShot(openingClip);
            yield return new WaitForSeconds(openingClip.length);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }

        openingFinished = true;

        ShowOpeningChoice();
    }

    private void ShowOpeningChoice()
    {
        openingChoiceShown = true;

        if (choice01 != null)
        {
            choice01.SetActive(true);
        }

        Debug.Log("CHOICE 01: Opening choice is now available.");
    }

    public void AskWhoIsWaiting()
    {
        if (!openingChoiceShown)
        {
            return;
        }

        if (openingChoiceResolved)
        {
            return;
        }

        openingChoiceResolved = true;
        askedWhoIsWaiting = true;

        if (choice01 != null)
        {
            choice01.SetActive(false);
        }

        StartCoroutine(WhoIsWaitingResponse());
    }

    private IEnumerator WhoIsWaitingResponse()
    {
        Debug.Log("NURSE: You'll understand when you see him.");
        Debug.Log("NURSE: He's waiting in the last room.");

        if (nurseAudioSource != null && whoIsWaitingClip != null)
        {
            nurseAudioSource.PlayOneShot(whoIsWaitingClip);
            yield return new WaitForSeconds(whoIsWaitingClip.length);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }

        FinishOpening();
    }

    public void AskAboutDischarge()
    {
        if (!openingChoiceShown)
        {
            return;
        }

        if (openingChoiceResolved)
        {
            return;
        }

        openingChoiceResolved = true;
        askedAboutDischarge = true;

        if (choice01 != null)
        {
            choice01.SetActive(false);
        }

        StartCoroutine(DischargeProblemResponse());
    }

    private IEnumerator DischargeProblemResponse()
    {
        Debug.Log("NURSE: Your paperwork is complete.");
        Debug.Log("NURSE: The remaining problem isn't paperwork.");

        if (nurseAudioSource != null && dischargeProblemClip != null)
        {
            nurseAudioSource.PlayOneShot(dischargeProblemClip);
            yield return new WaitForSeconds(dischargeProblemClip.length);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }

        FinishOpening();
    }

    private void FinishOpening()
    {
        SetOpeningDoors(true);

        if (patient17 != null)
        {
            patient17.SetActive(true);
        }

        if (nurse != null)
        {
            nurse.SetActive(false);
        }

        openingComplete = true;

        Debug.Log("OPENING COMPLETE: Doors are open, Patient 17 is active, and Nurse is hidden.");
    }

    private void SetOpeningDoors(bool open)
    {
        if (door01Closed != null)
        {
            door01Closed.SetActive(!open);
        }

        if (door01Open != null)
        {
            door01Open.SetActive(open);
        }

        if (door02Closed != null)
        {
            door02Closed.SetActive(!open);
        }

        if (door02Open != null)
        {
            door02Open.SetActive(open);
        }
    }

    public void ReachPatient17Room()
    {
        if (!openingComplete)
        {
            return;
        }

        if (reachedPatient17Room)
        {
            return;
        }

        reachedPatient17Room = true;

        StartCoroutine(Patient17LockedSequence());
    }

    private IEnumerator Patient17LockedSequence()
    {
        Debug.Log("PATIENT 17: The door is locked.");
        Debug.Log("PATIENT 17: I can't open it from this side.");
        Debug.Log("PATIENT 17: Maybe there is something in the doctor's office or the nurse lounge.");

        if (patient17AudioSource != null && lockedRoomClip != null)
        {
            patient17AudioSource.PlayOneShot(lockedRoomClip);
            yield return new WaitForSeconds(lockedRoomClip.length);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }

        ShowPatient17RoomChoice();
    }

    private void ShowPatient17RoomChoice()
    {
        patient17RoomChoiceShown = true;

        if (choice02 != null)
        {
            choice02.SetActive(true);
        }

        Debug.Log("CHOICE 02: Doctor's Office or Nurse Lounge.");
    }

    public void ChooseDoctorOffice()
    {
        if (!patient17RoomChoiceShown)
        {
            return;
        }

        if (patient17RoomChoiceResolved)
        {
            return;
        }

        patient17RoomChoiceResolved = true;
        choseDoctorOffice = true;

        if (choice02 != null)
        {
            choice02.SetActive(false);
        }

        if (doctorOfficeDoor != null)
        {
            doctorOfficeDoor.SetActive(false);
        }

        Debug.Log("BRANCH: Player chose the doctor's office.");
        Debug.Log("DOOR: Doctor's office is now accessible.");
    }

    public void ChooseNurseLounge()
    {
        if (!patient17RoomChoiceShown)
        {
            return;
        }

        if (patient17RoomChoiceResolved)
        {
            return;
        }

        patient17RoomChoiceResolved = true;
        choseNurseLounge = true;

        if (choice02 != null)
        {
            choice02.SetActive(false);
        }

        if (nurseLoungeDoor != null)
        {
            nurseLoungeDoor.SetActive(false);
        }

        Debug.Log("BRANCH: Player chose the nurse lounge.");
        Debug.Log("DOOR: Nurse lounge is now accessible.");
    }
}