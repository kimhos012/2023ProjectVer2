using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecendPhotoTrigger : MonoBehaviour
{
    [Header("2번째 사진")]
    public GameObject SecendPhoto;
    [Header("다음 순서의 사진n일지")]
    public GameObject NextPhoto;
    public GameObject NextDiary;
    public GameObject NextTrigger;

    void Update()
    {
        if(SecendPhoto.gameObject.activeSelf == false)
        {
            NextPhoto.SetActive(true);
            NextDiary.SetActive(true);
            NextTrigger.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
