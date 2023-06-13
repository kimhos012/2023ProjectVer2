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
    
    public Text InteractionMsg;

    [Space(10)]
    public LayerMask layerMask;     //ITEM�� �����ϱ�

    private bool itemDisplay;
    private bool openDisplay;
    

    void Start()
    {
        InteractionMsg.text = " ";
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
                InteractionMsg.text = "E �� ���� ������ �ݽ��ϴ�.";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    onhit.transform.GetComponent<Item>().OnPickup();

                }
            }

            else if (onhit.collider.CompareTag("OpenClose"))       //��¦����
            {
                if (onhit.transform.GetComponent<Open>().isOpen)
                {
                    InteractionMsg.text = "E �� ���� ���� �ݽ��ϴ�.";
                }
                else if (onhit.transform.GetComponent<Open>().isOpen == false)
                {
                    InteractionMsg.text = "E �� ���� ���� ���ϴ�.";
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
                    InteractionMsg.text = "E �� ���� ������ �ݽ��ϴ�.";
                }
                else if (onhit.transform.GetComponent<Open>().isOpen == false)
                {
                    InteractionMsg.text = "E �� ���� ������ ���ϴ�.";
                }
                if (Input.GetKeyDown(KeyCode.E))                //Use INter
                {
                    onhit.transform.GetComponent<Open>().Opening();
                }
            }
            else if (onhit.collider.CompareTag("Exit"))      //NAGAGEE DOOR
            {
                InteractionMsg.text = "E �� ���� ������ �����ϴ�.";
            }

        }
        else { InteractionMsg.text = null; }
    }


    private void Update()
    {
        Interaction();


        illgS = DontDestory.illgeeCount;
        photos = DontDestory.photoCount;
    }
    
}
