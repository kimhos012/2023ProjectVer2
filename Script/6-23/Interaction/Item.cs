using Newtonsoft.Json.Linq;
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
    }

    void ItemConvert()
    {
        if (ItemType == "Photo")     //사진 (6개가 필요함)
        {
            switch(ItemNum)
            {
                case 0:
                    if (DontDestory.photoCount == 0)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                case 1:
                    if (DontDestory.photoCount == 1)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                case 2:
                    if (DontDestory.photoCount == 2)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                case 3:
                    if (DontDestory.photoCount == 3)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                case 4:
                    if (DontDestory.photoCount == 4)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                case 5:
                    if (DontDestory.photoCount == 5)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                case 6:
                    if (DontDestory.photoCount == 6)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                default: break;
            }

            //DontDestory.photoCount++;
        }
        else if (ItemType == "1Gee")        //일지 (8장)
        {
            switch (ItemNum)
            {
                case 0:
                    if (DontDestory.illgeeCount == 0)         //이런식으로 약간 단순형으로 코드를 짤때마다 기분이 조금 안좋아요
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                case 1:
                    if (DontDestory.illgeeCount == 1)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                case 2:
                    if (DontDestory.illgeeCount == 2)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                case 3:
                    if (DontDestory.illgeeCount == 3)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                case 4:
                    if (DontDestory.illgeeCount == 4)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                case 5:
                    if (DontDestory.illgeeCount == 5)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                case 6:
                    if (DontDestory.illgeeCount == 6)         //아이템 순서대로 줍게 만들라고 한 쓸모없는거
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //아이템 비활성화
                    }
                    else break;
                    break;
                default: break;
            }

            //DontDestory.illgeeCount++;
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
