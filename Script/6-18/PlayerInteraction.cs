using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{

    public Transform cam;


    [Header("아이템 수집")]
    public byte photos;
    public byte illgS;

    [Space(10f)]
    public GameObject crosshairCol;
    public bool CanInteraction = true;      //상작용
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
    public GameObject UCantGoThere;

    [Space(10)]
    public LayerMask layerMask;     //구분하기
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
        UCantGoThere.SetActive(false);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject == Worldborader)
        {
            UCantGoThere.SetActive(true);
        }
        else
        {
            UCantGoThere.SetActive(false);
        }
    }

    public void Interaction()
    {
        RaycastHit onhit;
        Debug.DrawRay(cam.position, cam.transform.forward * 3f, Color.blue);        //보이는 레이저
        if (Physics.Raycast(cam.position, cam.transform.forward, out onhit, 3f , layerMask))
        {
            if (onhit.collider.CompareTag("Item"))       //아이템이긴 한다
            {
                //InteractionMsg.text = "E 를 눌러 물건을 줍습니다.";

                if(onhit.transform.GetComponent<Item>().ItemType == "Photo")        //아이템 종류감지
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

            else if (onhit.collider.CompareTag("OpenClose"))       //문짝감지
            {
                if (onhit.transform.GetComponent<Open>().isOpen)
                {
                    //InteractionMsg.text = "E 를 눌러 문을 닫습니다.";
                    OpenDoor.SetActive(false);
                    CloseDoor.SetActive(true);
                }
                else if (onhit.transform.GetComponent<Open>().isOpen == false)
                {
                    //InteractionMsg.text = "E 를 눌러 문을 엽니다.";
                    OpenDoor.SetActive(true);
                    CloseDoor.SetActive(false);
                }
                if (Input.GetKeyDown(KeyCode.E))                //Use INter
                {
                    onhit.transform.GetComponent<Open>().Opening();
                }
            }

            else if (onhit.collider.CompareTag("Desk"))          //서랍
            {
                if (onhit.transform.GetComponent<Open>().isOpen)
                {
                    //InteractionMsg.text = "E 를 눌러 서랍을 닫습니다.";
                }
                else if (onhit.transform.GetComponent<Open>().isOpen == false)
                {
                    //InteractionMsg.text = "E 를 눌러 서랍을 엽니다.";
                }
                if (Input.GetKeyDown(KeyCode.E))                //Use INter
                {
                    onhit.transform.GetComponent<Open>().Opening();
                }
            }
            else if (onhit.collider.CompareTag("Exit"))      //NAGAGEE DOOR
            {
                //InteractionMsg.text = "E 를 눌러 밖으로 나갑니다.";
                OpenDoor.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    onhit.transform.GetComponent<Exit>().OnExit();
                }
            }
            crosshairCol.GetComponent<Image>().color = Color.white;
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


    private void Update()
    {
        Interaction();


        illgS = DontDestory.illgeeCount;
        photos = DontDestory.photoCount;
    }
    
}
