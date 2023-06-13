using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{

    [Header("�� config")]
    [Tooltip("0 = ���ư��°�, 1 = ������ ���°�")]
    public byte doorType;

    public bool isOpen;
    public bool OpenAngle;


    [Header("Door Obj")]

    [Tooltip("���ݴ¼Ҹ�")]
    public GameObject Sound;


    private bool DDoublepush;
    private float Yangle;

    private void Start()
    {
        Yangle = GetComponent<Transform>().eulerAngles.y;           //Save First position

        if (isOpen && doorType == 0)
            StartCoroutine(openDooor());
        else if (isOpen && doorType == 1)
            StartCoroutine(openDesk());
    }

    public void Opening()
    {
        if (isOpen && !DDoublepush)
        {
            isOpen = false;
            StartCoroutine(openDooor());
        }
        else if (!isOpen && !DDoublepush)
        {
            isOpen = true;
            StartCoroutine(openDooor());
        }
        if (DDoublepush)
        {
            return;
        }
    }

    IEnumerator openDooor()
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

    IEnumerator openDesk()
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

