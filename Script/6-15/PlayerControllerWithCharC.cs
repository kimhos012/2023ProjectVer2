using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerControllerWithCharC : MonoBehaviour
{
    //아담 스미스의 개쩌는 보이지 않는 함수들
    private float currentSpeed;
    private float mouseH, mouseV = 0.0f;
    [Header("player")]
    [SerializeField]
    private Transform playerTransform;
    private bool toggleF;
    private bool Crouching;


    private CharacterController characterController;
    private Vector3 moveDir;


    #region playerSetting
    [Header("Player Setting")]
    [Tooltip("�÷��̾� ������")]
    public float MoveSpeed;
    [Tooltip("�߷�")]
    public float GravityValue = 0.98f;      //�߷°��ӵ��ε�... ������ �ð��� ��� �׳� �Ʒ��� �������°�
    private float Sensitivity;

    [Tooltip("Camera")]
    public Transform Camera;


    [Space(10f)]
    [Header("Player Controll Setting")]

    public bool CanSprint = true;            //�޸���
    [Tooltip("�޸��� �ӵ�")]
    public float SprintSpeed;

    [Space(10f)]

    public bool CanCrouch = true;          //�ɱ�
    [Tooltip("�ɴ� ����")]
    [Range(0.1f, 1f)]
    public float crouchA;
    [Tooltip("�ɾ����� �ӵ�")]
    public float CrouchSpeed;

    [Space(10f)]

    public bool CanShoot;           //�m
    [Tooltip("�Ѿ˰�����")]
    public float Ammo;

    [Space(10f)]

    [Tooltip("������")]
    public GameObject Flash;
    [Tooltip("������ �Ҹ�")]
    public GameObject FlashSound;
    [Tooltip("�������� �����Ÿ� ����")]
    public bool ActiveGlitter;


    [Space(10f)]
    public GameObject FootSound;
    public GameObject SprintSound;

    #endregion



    private void Start()
    {
        toggleF = false;
        Flash.SetActive(false);

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MouseControll();  //���콺 ����
        speedSet();         //�ӵ�����
        Moving();          //������
        FlashToggle();      //������
        if (CanCrouch)
        {
            StartCoroutine(Crouch());
        }

    }

    private void FixedUpdate()          //�δ��� ���ϰ�(?) Fixed��
    {
        if(Sensitivity != Option.sensitvity)            // change Option Setting
            Sensitivity = Option.sensitvity;
    }


    void MouseControll()
    {
        mouseH += Input.GetAxis("Mouse X") * Sensitivity;
        mouseV += Input.GetAxis("Mouse Y") * Sensitivity;     //Input


        if (mouseH > 360)           //���� ����
        {
            mouseH -= 360;
        }
        mouseV = Mathf.Clamp(mouseV, -90, 90);      //���� ����

        transform.rotation = Quaternion.Euler(0, mouseH, 0);
        Camera.eulerAngles = new Vector3 (-mouseV, mouseH, 0);       //ī�޶� ����

    }

    Vector3 lastPosition;

    void MoveTo(Vector3 direction)
    {
        //moveDir = direction;
        Vector3 movedis = Camera.rotation * direction;
        moveDir = new Vector3(movedis.x, -GravityValue, movedis.z);
    }

    void Moving()     //�÷��̾� �����Ӹ� ����
    {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        MoveTo(new Vector3(hor, 0 , ver));
        characterController.Move(Time.deltaTime * currentSpeed * moveDir);

       if(hor != 0 || ver != 0)     //move Detect
        {
            if(Input.GetKey(KeyCode.LeftShift))         //Detect Sprint
            {
                SprintSound.SetActive(true);
                FootSound.SetActive(false);
            }
            else
            {
                SprintSound.SetActive(false);
                FootSound.SetActive(true);
            }
        }
       else
        {
            FootSound.SetActive(false);
            SprintSound.SetActive(false);
        }
    }

    

    private IEnumerator Crouch()      //앉기
    {

        if (Input.GetKey(KeyCode.LeftControl) && !Crouching)
        {
            Crouching = true;
            for (int i = 0; i < (crouchA * 30); i++)
            {
                transform.localScale += new Vector3(0f, -0.025f, 0f);
                yield return new WaitForSecondsRealtime(.01f);
            }
        }
        else if (!Input.GetKey(KeyCode.LeftControl) && Crouching)
        {
            Crouching = false;
            for (int i = 0; i < (crouchA * 30); i++)
            {
                transform.localScale += new Vector3(0f, 0.025f, 0f);
                yield return new WaitForSecondsRealtime(.01f);
            }
        }
        yield break;
    }

    void speedSet()     //�ӵ�����
    {
        if(Input.GetKey(KeyCode.LeftControl) && CanCrouch)       //�ɱ�
        {
            currentSpeed = CrouchSpeed;
        }
        else if(Input.GetKey(KeyCode.LeftShift) && CanSprint)    //�޸���
        {
            currentSpeed = SprintSpeed;
        }
        else
        {
            currentSpeed = MoveSpeed;
        }
    }

    void FlashToggle()
    {
        

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (toggleF)
            {
                toggleF = false;

                Flash.SetActive(false);
            }
            else
            {
                toggleF = true;
                Flash.SetActive(true);

            }
            FlashSound.GetComponent<AudioSource>().Play();
        }
    }
}
