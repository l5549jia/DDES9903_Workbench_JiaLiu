using UnityEngine;

public class Choice2BranchController : MonoBehaviour
{
    [Header("Choice 02")]
    public GameObject choice02;

    [Header("Branch Doors")]
    public GameObject doctorOfficeDoor;
    public GameObject nurseLoungeDoor;

    [Header("Doctor Office")]
    public GameObject doctorComputerOutline;

    [Header("Nurse Lounge")]
    public GameObject nurseKey;
    public GameObject nurseKeyOutline;
    public GameObject nurseLoungeClue;

    [Header("Patient 17 Room")]
    public GameObject patient17RoomDoor;

    [Header("Branch State")]
    public bool branchChosen = false;
    public bool choseDoctorOffice = false;
    public bool choseNurseLounge = false;

    [Header("Item State")]
    public bool hasPassword = false;
    public bool hasKey = false;
    public bool patient17RoomUnlocked = false;

    private void Start()
    {
        if (doctorComputerOutline != null)
        {
            doctorComputerOutline.SetActive(false);
        }

        if (nurseKeyOutline != null)
        {
            nurseKeyOutline.SetActive(false);
        }

        if (nurseLoungeClue != null)
        {
            nurseLoungeClue.SetActive(false);
        }
    }

    public void ChooseDoctorOffice()
    {
        if (branchChosen)
        {
            return;
        }

        branchChosen = true;
        choseDoctorOffice = true;

        if (choice02 != null)
        {
            choice02.SetActive(false);
        }

        if (doctorOfficeDoor != null)
        {
            doctorOfficeDoor.SetActive(false);
        }

        if (doctorComputerOutline != null)
        {
            doctorComputerOutline.SetActive(true);
        }

        Debug.Log("CHOICE 02: Doctor's Office selected.");
        Debug.Log("CLUE: Doctor's computer is highlighted.");
    }

    public void ChooseNurseLounge()
    {
        if (branchChosen)
        {
            return;
        }

        branchChosen = true;
        choseNurseLounge = true;

        if (choice02 != null)
        {
            choice02.SetActive(false);
        }

        if (nurseLoungeDoor != null)
        {
            nurseLoungeDoor.SetActive(false);
        }

        if (nurseKeyOutline != null)
        {
            nurseKeyOutline.SetActive(true);
        }

        if (nurseLoungeClue != null)
        {
            nurseLoungeClue.SetActive(true);
        }

        Debug.Log("CHOICE 02: Nurse Lounge selected.");
        Debug.Log("CLUE: Room 17 key is highlighted.");
    }

    public void ObtainPassword()
    {
        if (!choseDoctorOffice)
        {
            return;
        }

        if (hasPassword)
        {
            return;
        }

        hasPassword = true;

        if (doctorComputerOutline != null)
        {
            doctorComputerOutline.SetActive(false);
        }

        Debug.Log("PATIENT RECORD: Patient 17.");
        Debug.Log("DISCHARGE STATUS: INCOMPLETE.");
        Debug.Log("PASSWORD ACQUIRED: 1127.");

        UnlockPatient17Room();
    }

    public void ObtainKey()
    {
        if (!choseNurseLounge)
        {
            return;
        }

        if (hasKey)
        {
            return;
        }

        hasKey = true;

        if (nurseKeyOutline != null)
        {
            nurseKeyOutline.SetActive(false);
        }

        Debug.Log("CLUE: He keeps asking to leave.");
        Debug.Log("KEY ACQUIRED: Room 17.");

        if (nurseKey != null)
        {
            nurseKey.SetActive(false);
        }

        UnlockPatient17Room();
    }

    private void UnlockPatient17Room()
    {
        if (patient17RoomUnlocked)
        {
            return;
        }

        patient17RoomUnlocked = true;

        if (patient17RoomDoor != null)
        {
            patient17RoomDoor.SetActive(false);
        }

        Debug.Log("DOOR: Patient 17 room is now unlocked.");
    }
}