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
        if (ItemType == "Photo")     //���� (6���� �ʿ���)
        {
            switch(ItemNum)
            {
                case 0:
                    if (DontDestory.photoCount == 0)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                case 1:
                    if (DontDestory.photoCount == 1)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                case 2:
                    if (DontDestory.photoCount == 2)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                case 3:
                    if (DontDestory.photoCount == 3)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                case 4:
                    if (DontDestory.photoCount == 4)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                case 5:
                    if (DontDestory.photoCount == 5)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                case 6:
                    if (DontDestory.photoCount == 6)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.photoCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                default: break;
            }

            //DontDestory.photoCount++;
        }
        else if (ItemType == "1Gee")        //���� (8��)
        {
            switch (ItemNum)
            {
                case 0:
                    if (DontDestory.illgeeCount == 0)         //�̷������� �ణ �ܼ������� �ڵ带 ©������ ����� ���� �����ƿ�
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                case 1:
                    if (DontDestory.illgeeCount == 1)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                case 2:
                    if (DontDestory.illgeeCount == 2)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                case 3:
                    if (DontDestory.illgeeCount == 3)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                case 4:
                    if (DontDestory.illgeeCount == 4)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                case 5:
                    if (DontDestory.illgeeCount == 5)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                case 6:
                    if (DontDestory.illgeeCount == 6)         //������ ������� �ݰ� ������ �� ������°�
                    {
                        DontDestory.illgeeCount++;
                        gameObject.SetActive(false);        //������ ��Ȱ��ȭ
                    }
                    else break;
                    break;
                default: break;
            }

            //DontDestory.illgeeCount++;
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
