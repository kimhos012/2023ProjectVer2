using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPhotoTrigger : MonoBehaviour
{
    [Header("3번째 사진")]
    public GameObject ThirdPhoto;
    [Header("2층 계단 박스")]
    public GameObject Boxes1;
    public GameObject Boxes2;
    public GameObject BoxesSound;
    [Header("다음 순서의 사진n일지")]
    public GameObject NextPhoto;
    public GameObject NextDiary;
    public GameObject NextTrigger;

    void Update()
    {
        if(ThirdPhoto.gameObject.activeSelf == false)
        {
            Debug.Log("2층 계단의 장애물이 사라졌다.");
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
