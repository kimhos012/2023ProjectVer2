using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour
{
    public bool ExitDoor;       //detect door �ù�
    public bool isLocked;

    [Tooltip("���ݴ¼Ҹ�")]
    public GameObject OpenSound;
    [Tooltip("��ܹ����ݴ¼Ҹ�")]
    public GameObject TrapDoorOpenSound;
    [Tooltip("��乮���Ҹ�")]
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
            Debug.Log("�� ���� ����ִ�.");
        }
    }
}
