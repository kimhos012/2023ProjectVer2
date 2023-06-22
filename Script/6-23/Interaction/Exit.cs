using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour
{
    public bool ExitDoor;       //detect door 시발
    public bool isLocked;
    [Space(10f)]
    public bool Flip;
    public bool trap;

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
            Debug.Log("이 문은 잠겨있다.");
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
