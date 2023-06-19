using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPhotoTrigger : MonoBehaviour
{
    [Header("3��° ����")]
    public GameObject ThirdPhoto;
    [Header("2�� ��� �ڽ�")]
    public GameObject Boxes1;
    public GameObject Boxes2;
    public GameObject BoxesSound;
    [Header("���� ������ ����n����")]
    public GameObject NextPhoto;
    public GameObject NextDiary;
    public GameObject NextTrigger;

    void Update()
    {
        if(ThirdPhoto.gameObject.activeSelf == false)
        {
            Debug.Log("2�� ����� ��ֹ��� �������.");
            BoxesSound.GetComponent<AudioSource>().Play();
            Boxes1.SetActive(false);
            Boxes2.SetActive(false);
            NextPhoto.SetActive(true);
            NextDiary.SetActive(true);
            NextTrigger.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
