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
    public bool isLocked;

    [Header("Door Obj")]

    [Tooltip("���ݴ¼Ҹ�")]
    public GameObject Sound;
    [Tooltip("��乮���Ҹ�")]
    public GameObject LockedSound;


    private bool DDoublepush;
    private float Yangle;
    private Vector3 Backupposition;

    private void Start()
    {
        if(doorType == 0)
        {
            Yangle = GetComponent<Transform>().eulerAngles.y;           //Save First position
        }
        else
        {
            Backupposition = GetComponent<Transform>().position;
        }

        

        if (isOpen && doorType == 0)
            if(OpenAngle)
                transform.eulerAngles += new Vector3(0, 80, 0);
            else
                transform.eulerAngles -= new Vector3(0, 80, 0);

        else if (isOpen && doorType == 1)
            transform.position += new Vector3(0, 0, 24);
    }

    public void Opening()
    {
        if (!isLocked)
        {
            switch(doorType)
            {
                case 0:
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
                    break;
                case 1:
                    if (isOpen && !DDoublepush)
                    {
                        isOpen = false;
                        StartCoroutine(openDesk());
                    }
                    else if (!isOpen && !DDoublepush)
                    {
                        isOpen = true;
                        StartCoroutine(openDesk());
                    }
                    if (DDoublepush)
                    {
                        return;
                    }
                    break;
            }
        }
        else
        {
            Debug.Log("This Door is Locked");
            LockedSound.GetComponent<AudioSource>().Play();
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
            DDoublepush = true;                                         
            Sound.GetComponent<AudioSource>().Play();
            for (int i = 0; i < 19; i++)
            {
                transform.localPosition += new Vector3(0, 0, 1);
                yield return new WaitForSecondsRealtime(.005f);
            }
            DDoublepush = false;
        }
        else if (!isOpen && !DDoublepush)
        {
            DDoublepush = true;
            Sound.GetComponent<AudioSource>().Play();
            for (int i = 0; i < 19; i++)
            {
                transform.localPosition -= new Vector3(0, 0, 1);
                yield return new WaitForSecondsRealtime(.005f);
            }
            transform.position = Backupposition;      //Ȥ�ø� ���⿡ ������ �߻� ��
            DDoublepush = false;
        }
        yield return null;
    }
}

