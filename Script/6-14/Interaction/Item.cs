using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    [Header("Photo, 1Gee")]
    public string ItemType;
    public byte ItemNum;

    public void OnPickup()
    {
        ItemConvert();

        gameObject.SetActive(false);        //아이템 비활성화
    }

    void ItemConvert()
    {
        if (ItemType == "Photo")     //사진 (6개가 필요함)
        {
            DontDestory.photoCount++;
        }
        else if (ItemType == "1Gee")        //일지 (8장)
        {
            DontDestory.illgeeCount++;
        }
        else
        {
            Debug.Log("식별되지 않은 아이템입니다.");
            return;
        }        //존재하지 않는 아이템일경우
    }

    void OnCollisionStay(Collision other)
    {
        
    }
}
