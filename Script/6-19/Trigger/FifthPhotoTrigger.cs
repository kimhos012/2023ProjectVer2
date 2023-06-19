using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthPhotoTrigger : MonoBehaviour
{
    [Header("5��° ����")]
    public GameObject FifthPhoto;
    [Header("���Ͻ� ��")]
    public GameObject BasementDoor;
    private Open basementDoor;
    [Header("Ȱ��ȭ �� Ŀ��")]
    public GameObject GhostBD;
    public GameObject GBDTrigger;
    [Header("����")]
    public GameObject Bottle1;
    public GameObject Bottle2;
    private AudioSource bottledrop;
    [Header("���� ������ ����n����")]
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
        if(FifthPhoto.gameObject.activeSelf == false)   //5��° ���� ȹ�� ����
        {
            Debug.Log("���Ͻ� ���� ���ȴ�.");
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
