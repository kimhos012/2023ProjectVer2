using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour
{
    public bool ExitDoor;       //detect door 시발
    public bool isLocked;

    [Tooltip("여닫는소리")]
    public GameObject OpenSound;
    [Tooltip("계단문여닫는소리")]
    public GameObject TrapDoorOpenSound;
    [Tooltip("잠긴문고리소리")]
    public GameObject LockedSound;

    public void OnExit()
    {
        if (!isLocked)
        {
            if (ExitDoor)
            {
                TrapDoorOpenSound.GetComponent<AudioSource>().Play();
                SceneManager.LoadScene("OutSideToEnding");
            }
            else
            {
                OpenSound.GetComponent<AudioSource>().Play();
                SceneManager.LoadScene("INGAME");
            }
        }
        else
        {
            LockedSound.GetComponent<AudioSource>().Play();
            Debug.Log("이 문은 잠겨있다.");
        }
    }
}
