using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{

    public Transform cam;

    [Header("������ ����")]
    public byte photos;
    public byte illgS;

    [Space(10f)]

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

    [Space(10)]
    public LayerMask layerMask;     //ITEM�� �����ϱ�

    private bool itemDisplay;
    private bool openDisplay;
    

    void Start()
    {
        //InteractionMsg.text = " ";

        OpenDoor.SetActive(false);
        CloseDoor.SetActive(false);
        OpenDesk.SetActive(false);
        CloseDesk.SetActive(false);
        PickupItem.SetActive(false);
        PickupDaily.SetActive(false);

    }

    public void Interaction()
    {
        RaycastHit onhit;
        Debug.DrawRay(cam.position, cam.transform.forward * 3f, Color.blue);        //���̴� ������
        if (Physics.Raycast(cam.position, cam.transform.forward, out onhit, 3f , layerMask))
        {
            //Debug.Log(onhit.collider.gameObject);
            
            if (onhit.collider.CompareTag("Item"))       //������ ����.
            {
                //InteractionMsg.text = "E �� ���� ������ �ݽ��ϴ�.";
                PickupItem.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    onhit.transform.GetComponent<Item>().OnPickup();

                }
            }

            else if (onhit.collider.CompareTag("OpenClose"))       //��¦����
            {
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
                if (onhit.transform.GetComponent<Open>().isOpen)
                {
                    //InteractionMsg.text = "E �� ���� ������ �ݽ��ϴ�.";
                }
                else if (onhit.transform.GetComponent<Open>().isOpen == false)
                {
                    //InteractionMsg.text = "E �� ���� ������ ���ϴ�.";
                }
                if (Input.GetKeyDown(KeyCode.E))                //Use INter
                {
                    onhit.transform.GetComponent<Open>().Opening();
                }
            }
            else if (onhit.collider.CompareTag("Exit"))      //NAGAGEE DOOR
            {
                //InteractionMsg.text = "E �� ���� ������ �����ϴ�.";
            }

        }
        else
        {
            //InteractionMsg.text = null;
            OpenDoor.SetActive(false);
            CloseDoor.SetActive(false);
            OpenDesk.SetActive(false);
            CloseDesk.SetActive(false);
            PickupItem.SetActive(false);
            PickupDaily.SetActive(false);
        }
    }


    private void Update()
    {
        Interaction();


        illgS = DontDestory.illgeeCount;
        photos = DontDestory.photoCount;
    }
    
}
