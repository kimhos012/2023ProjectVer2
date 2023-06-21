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
    public GameObject GlassTrigger;


    void Update()
    {
        if(ThirdPhoto.gameObject.activeSelf == false)
        {
            Debug.Log("2�� ����� ��ֹ��� �������.");
            //glassExplosion.GetComponent<AudioSource>().Play();
            BoxesSound.GetComponent<AudioSource>().Play();
            Boxes1.SetActive(false);
            Boxes2.SetActive(false);
            GlassTrigger.SetActive(true);
            NextPhoto.SetActive(true);
            NextDiary.SetActive(true);
            NextTrigger.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
