using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorTrigger : MonoBehaviour
{
    [Tooltip("1��° ����")]
    public GameObject FirstPhoto;
    [Tooltip("����")]
    public GameObject MainDoor1;
    private Exit mainDoor1;
    public GameObject MainDoor2;
    private Exit mainDoor2;

    void Awake()
    {
        mainDoor1 = MainDoor1.GetComponent<Exit>();
        mainDoor2 = MainDoor2.GetComponent<Exit>();
    }

    void Update()
    {
        if(FirstPhoto.gameObject.activeSelf == false)
        {
            Debug.Log("������ ���ȴ�.");
            mainDoor1.isLocked = false;
            mainDoor2.isLocked = false;
            this.gameObject.SetActive(false);
        }
    }
}
