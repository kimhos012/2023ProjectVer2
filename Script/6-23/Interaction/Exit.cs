using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour
{
    public bool ExitDoor;       //detect door �ù�
    public bool isLocked;
    [Space(10f)]
    public bool Flip;
    public bool trap;

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
                
            }
            else
            {
                OpenSound.GetComponent<AudioSource>().Play();
                
            }
            StartCoroutine(sec());
        }
        else
        {
            LockedSound.GetComponent<AudioSource>().Play();
            Debug.Log("�� ���� ����ִ�.");
        }
    }

    IEnumerator sec()
    {
        if (ExitDoor)
        {   
            if(trap)
            {
                if (!Flip)
                {
                    for (int i = 0; i < 29; i++)
                    {
                        transform.localPosition += new Vector3(0, 0.1f, 0);
                        yield return new WaitForSecondsRealtime(.01f);
                    }
                }
                else
                {
                    for (int i = 0; i < 29; i++)
                    {
                        transform.localPosition -= new Vector3(0, 0.1f, 0);
                        yield return new WaitForSecondsRealtime(.01f);
                    }
                }
            }
            else if (!Flip)
            {
                for (int i = 0; i < 79; i++)
                {
                    transform.eulerAngles += new Vector3(0, 0.1f, 0);
                    yield return new WaitForSecondsRealtime(.01f);
                }
            }
            else
            {
                for (int i = 0; i < 79; i++)
                {
                    transform.eulerAngles -= new Vector3(0, 0.1f, 0);
                    yield return new WaitForSecondsRealtime(.01f);
                }
            }
        }
        else
        {
            if (!Flip)
            {
                for (int i = 0; i < 79; i++)
                {
                    transform.eulerAngles += new Vector3(0, 1, 0);
                    yield return new WaitForSecondsRealtime(.01f);
                }
            }
            else
            {
                for (int i = 0; i < 79; i++)
                {
                    transform.eulerAngles -= new Vector3(0, 1, 0);
                    yield return new WaitForSecondsRealtime(.01f);
                }
            }
        }
        //WaitTime

        yield return new WaitForSecondsRealtime(.3f);
        if(ExitDoor)
        {
            SceneManager.LoadScene("OutSideToEnding");
        }
        else
        {
            SceneManager.LoadScene("INGAME");
        }
        yield return null;
    }


}
