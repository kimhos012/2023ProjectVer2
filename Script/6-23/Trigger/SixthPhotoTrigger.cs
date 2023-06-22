using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthPhotoTrigger : MonoBehaviour
{
    [Header("6��° ����")]
    public GameObject SixthPhoto;
    [Header("���� �ⱸ")]
    public GameObject ExitDoor1;
    private Exit exitDoor1;
    public GameObject ExitDoor2;
    private Exit exitDoor2;

    void Awake()
    {
        exitDoor1 = ExitDoor1.GetComponent<Exit>();
        exitDoor2 = ExitDoor2.GetComponent<Exit>();
    }

    void Update()
    {
        if(SixthPhoto.gameObject.activeSelf == false)
        {
            Debug.Log("���Ͻ� �ⱸ�� ���ȴ�.");
            exitDoor1.isLocked = false;
            exitDoor2.isLocked = false;
            this.gameObject.SetActive(false);
        }
    }
}
