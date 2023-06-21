using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthPhotoTrigger : MonoBehaviour
{
    [Header("6번째 사진")]
    public GameObject SixthPhoto;
    [Header("지하 출구")]
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
            Debug.Log("지하실 출구가 열렸다.");
            exitDoor1.isLocked = false;
            exitDoor2.isLocked = false;
            this.gameObject.SetActive(false);
        }
    }
}
