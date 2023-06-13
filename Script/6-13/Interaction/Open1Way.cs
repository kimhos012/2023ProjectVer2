using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open1Way : MonoBehaviour
{
    
    [Header("문 config")]

    public bool isOpen;
    [Tooltip("체크 시, +각도로 문이 열립니다")]
    public bool OpenAngle;

    [Header("Door Obj")]
    [Tooltip("여닫는소리")]
    public GameObject Sound;


    private bool DDoublepush;
    private float Yangle;

    private void Start()
    {
        Yangle = GetComponent<Transform>().eulerAngles.y;

    }

    public void Opening()
    {
        if (isOpen && !DDoublepush)
        {
            isOpen = false;
            StartCoroutine(openAAAAA());
        }
        else if (!isOpen && !DDoublepush)
        {
            isOpen = true;
            StartCoroutine(openAAAAA());
        }
        if(DDoublepush)
        {
            return;
        }
    }

    IEnumerator openAAAAA()
    {
        if (OpenAngle)
        {
            if (isOpen && !DDoublepush)                             
            {
                DDoublepush = true;                                         //+각도로 문이 열림
                Sound.GetComponent<AudioSource>().Play();
                for (int i = 0; i < 79; i++)
                {
                    transform.eulerAngles += new Vector3(0, 1, 0);
                    yield return new WaitForSecondsRealtime(.005f);
                }
                DDoublepush = false;
            }
            else if (!isOpen && !DDoublepush)
            {
                DDoublepush = true;
                Sound.GetComponent<AudioSource>().Play();
                for (int i = 0; i < 79; i++)
                {
                    transform.eulerAngles -= new Vector3(0, 1, 0);
                    yield return new WaitForSecondsRealtime(.005f);
                }
                transform.eulerAngles = new Vector3(0, Yangle, 0);      //혹시모를 방향에 문제가 발생 시
                DDoublepush = false;
            }
        }
        else
        {
            if (isOpen && !DDoublepush)                                      //-각도로 문이 열림
            {
                DDoublepush = true;
                Sound.GetComponent<AudioSource>().Play();
                for (int i = 0; i < 79; i++)
                {
                    transform.eulerAngles -= new Vector3(0, 1, 0);

                    yield return new WaitForSecondsRealtime(.005f);
                }
                DDoublepush = false;
            }
            else if (!isOpen && !DDoublepush)
            {
                DDoublepush = true;
                Sound.GetComponent<AudioSource>().Play();
                for (int i = 0; i < 79; i++)
                {
                    transform.eulerAngles += new Vector3(0, 1, 0);

                    yield return new WaitForSecondsRealtime(.005f);
                }
                transform.eulerAngles = new Vector3(0, Yangle, 0);      //혹시모를 방향에 문제가 발생 시
                DDoublepush = false;
            }
        }
        yield return null;
    }
}

