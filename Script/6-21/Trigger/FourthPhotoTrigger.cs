using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthPhotoTrigger : MonoBehaviour
{
    [Header("4번째 사진")]
    public GameObject FourthPhoto;
    [Header("다음 순서의 사진n일지")]
    public GameObject NextPhoto;
    public GameObject NextDiary;
    public GameObject NextTrigger;

    void Update()
    {
        if(FourthPhoto.gameObject.activeSelf == false)
        {
            NextPhoto.SetActive(true);
            NextDiary.SetActive(true);
            NextTrigger.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
