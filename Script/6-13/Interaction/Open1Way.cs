using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open1Way : MonoBehaviour
{
    
    [Header("�� config")]

    public bool isOpen;
    [Tooltip("üũ ��, +������ ���� �����ϴ�")]
    public bool OpenAngle;

    [Header("Door Obj")]
    [Tooltip("���ݴ¼Ҹ�")]
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
                DDoublepush = true;                                         //+������ ���� ����
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
                transform.eulerAngles = new Vector3(0, Yangle, 0);      //Ȥ�ø� ���⿡ ������ �߻� ��
                DDoublepush = false;
            }
        }
        else
        {
            if (isOpen && !DDoublepush)                                      //-������ ���� ����
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
                transform.eulerAngles = new Vector3(0, Yangle, 0);      //Ȥ�ø� ���⿡ ������ �߻� ��
                DDoublepush = false;
            }
        }
        yield return null;
    }
}

