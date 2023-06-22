using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{

    public Transform cam;


    [Header("������ ����")]
    public byte photos;
    public byte illgS;

    [Space(10f)]
    public GameObject crosshairCol;
    public bool CanInteraction = true;      //���ۿ�
    [Tooltip("Interaction Obj")]

    [Space(10f)]

    //public Text InteractionMsg;
    [Header("Display Image")]
    public GameObject OpenDoor;
    public GameObject CloseDoor;
    public GameObject OpenDesk;
    public GameObject CloseDesk;
    public GameObject PickupItem;
    public GameObject PickupDaily;

    [Space(5f)]
    public GameObject pickupSound;

    private bool itemDisplay;
    private bool openDisplay;
    [Space(10f)]
    public GameObject Worldborader;

    void Start()
    {
        OpenDoor.SetActive(false);
        CloseDoor.SetActive(false);
        OpenDesk.SetActive(false);
        CloseDesk.SetActive(false);
        PickupItem.SetActive(false);
        PickupDaily.SetActive(false);

    }

    private void Update()
    {
        Interaction();

        illgS = DontDestory.illgeeCount;        //���⼭ photo���� �߰���
        photos = DontDestory.photoCount;
    }


    public void Interaction()
    {
        //Everything - Player
        int layerMask = (-1) - (1 << LayerMask.NameToLayer("Player"));



        RaycastHit onhit;
        Debug.DrawRay(cam.position, cam.transform.forward * 3f, Color.blue);        //���̴� ������
        if (Physics.Raycast(cam.position, cam.transform.forward, out onhit, 3f, layerMask))
        {


            if (onhit.collider.CompareTag("Item"))       //�������̱� �Ѵ�
            {
                //InteractionMsg.text = "E �� ���� ������ �ݽ��ϴ�.";
                crosshairCol.GetComponent<Image>().color = Color.white;
                if (onhit.transform.GetComponent<Item>().ItemType == "Photo")        //������ ��������
                {
                    PickupItem.SetActive(true);
                }
                else
                {
                    PickupDaily.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.E))        //KeyDown to pickupItem
                {
                    onhit.transform.GetComponent<Item>().OnPickup();

                    pickupSound.GetComponent<AudioSource>().Play();
                }
            }

            else if (onhit.collider.CompareTag("OpenClose"))       //��¦����
            {
                crosshairCol.GetComponent<Image>().color = Color.white;
                if (onhit.transform.GetComponent<Open>().isOpen)
                {
                    //InteractionMsg.text = "E �� ���� ���� �ݽ��ϴ�.";
                    OpenDoor.SetActive(false);
                    CloseDoor.SetActive(true);
                }
                else if (onhit.transform.GetComponent<Open>().isOpen == false)
                {
                    //InteractionMsg.text = "E �� ���� ���� ���ϴ�.";
                    OpenDoor.SetActive(true);
                    CloseDoor.SetActive(false);
                }
                if (Input.GetKeyDown(KeyCode.E))                //Use INter
                {
                    onhit.transform.GetComponent<Open>().Opening();
                }
            }

            else if (onhit.collider.CompareTag("Desk"))          //����
            {
                crosshairCol.GetComponent<Image>().color = Color.white;
                if (onhit.transform.GetComponent<Open>().isOpen)
                {
                    //InteractionMsg.text = "E �� ���� ������ �ݽ��ϴ�.";
                    OpenDesk.SetActive(true);
                }
                else if (onhit.transform.GetComponent<Open>().isOpen == false)
                {
                    //InteractionMsg.text = "E �� ���� ������ ���ϴ�.";
                    CloseDesk.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.E))                //Use INter
                {
                    onhit.transform.GetComponent<Open>().Opening();
                }
            }
            else if (onhit.collider.CompareTag("Exit"))      //NAGAGEE DOOR
            {
                crosshairCol.GetComponent<Image>().color = Color.white;
                //InteractionMsg.text = "E �� ���� ������ �����ϴ�.";
                OpenDoor.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    onhit.transform.GetComponent<Exit>().OnExit();
                }
            }
            else
            {
                crosshairCol.GetComponent<Image>().color = Color.gray;
                OpenDoor.SetActive(false);
                CloseDoor.SetActive(false);
                OpenDesk.SetActive(false);
                CloseDesk.SetActive(false);
                PickupItem.SetActive(false);
                PickupDaily.SetActive(false);
            }
        }
        else
        {
            crosshairCol.GetComponent<Image>().color = Color.gray;
            OpenDoor.SetActive(false);
            CloseDoor.SetActive(false);
            OpenDesk.SetActive(false);
            CloseDesk.SetActive(false);
            PickupItem.SetActive(false);
            PickupDaily.SetActive(false);

        }
    }


}
