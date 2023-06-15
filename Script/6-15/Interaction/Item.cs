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

        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
    }

    void ItemConvert()
    {
        if (ItemType == "Photo")     //���� (6���� �ʿ���)
        {
            DontDestory.photoCount++;
        }
        else if (ItemType == "1Gee")        //���� (8��)
        {
            DontDestory.illgeeCount++;
        }
        else
        {
            Debug.Log("�ĺ����� ���� �������Դϴ�.");
            return;
        }        //�������� �ʴ� �������ϰ��
    }

    void OnCollisionStay(Collision other)
    {
        
    }
}
