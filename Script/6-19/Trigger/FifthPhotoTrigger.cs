using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthPhotoTrigger : MonoBehaviour
{
    [Header("5번째 사진")]
    public GameObject FifthPhoto;
    [Header("지하실 문")]
    public GameObject BasementDoor;
    private Open basementDoor;
    [Header("활성화 할 커신")]
    public GameObject GhostBD;
    public GameObject GBDTrigger;
    [Header("물통")]
    public GameObject Bottle1;
    public GameObject Bottle2;
    private AudioSource bottledrop;
    [Header("다음 순서의 사진n일지")]
    public GameObject NextPhoto;
    public GameObject NextDiary;
    public GameObject NextTrigger;

    void Awake()
    {
        basementDoor = BasementDoor.GetComponent<Open>();
        bottledrop = Bottle2.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(FifthPhoto.gameObject.activeSelf == false)   //5번째 사진 획득 감지
        {
            Debug.Log("지하실 문이 열렸다.");
            basementDoor.isLocked = false;
            Bottle1.SetActive(false);
            Bottle2.SetActive(true);
            bottledrop.Play();
            GBDTrigger.SetActive(true);
            //GhostBD.SetActive(true);
            NextPhoto.SetActive(true);
            NextDiary.SetActive(true);
            NextTrigger.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
