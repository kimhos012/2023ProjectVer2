using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerControllerWithCharC : MonoBehaviour
{
    //아담 스미스의 보이지 않는 변수
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
    [Tooltip("플레이어 움직임")]
    public float MoveSpeed;
    [Tooltip("중력")]
    public float GravityValue = 0.98f;      //중력가속도인데... 지금은 시간이 없어서 그냥 아래로 내려가는값
    private float Sensitivity;

    [Tooltip("Camera")]
    public Transform Camera;


    [Space(10f)]
    [Header("Player Controll Setting")]

    public bool CanSprint = true;            //달리기
    [Tooltip("달리기 속도")]
    public float SprintSpeed;

    [Space(10f)]

    public bool CanCrouch = true;          //앉기
    [Tooltip("앉는 강도")]
    [Range(0.1f, 1f)]
    public float crouchA;
    [Tooltip("앉았을때 속도")]
    public float CrouchSpeed;

    [Space(10f)]

    public bool CanShoot;           //헿
    [Tooltip("총알게이지")]
    public float Ammo;

    [Space(10f)]

    [Tooltip("손전등")]
    public GameObject Flash;
    [Tooltip("손전등 소리")]
    public GameObject FlashSound;
    [Tooltip("손전등이 지직거림 여부")]
    public bool ActiveGlitter;


    [Space(10f)]
    public GameObject FootSound;
    public GameObject SprintSound;

    #endregion



    private void Start()
    {
        toggleF = false;
        Flash.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MouseControll();  //마우스 조절
        speedSet();         //속도관리
        Moving();          //움직임
        FlashToggle();      //손전등
        if (CanCrouch)
        {
            StartCoroutine(Crouch());
        }

    }

    private void FixedUpdate()          //부담을 덜하게(?) Fixed로
    {
        if(Sensitivity != Option.sensitvity)            // change Option Setting
            Sensitivity = Option.sensitvity;
    }


    void MouseControll()
    {
        mouseH += Input.GetAxis("Mouse X") * Sensitivity;
        mouseV += Input.GetAxis("Mouse Y") * Sensitivity;     //Input


        if (mouseH > 360)           //각도 리셋
        {
            mouseH -= 360;
        }
        mouseV = Mathf.Clamp(mouseV, -90, 90);      //상하 제한

        transform.rotation = Quaternion.Euler(0, mouseH, 0);
        Camera.eulerAngles = new Vector3 (-mouseV, mouseH, 0);       //카메라 각도

    }

    Vector3 lastPosition;

    void MoveTo(Vector3 direction)
    {
        //moveDir = direction;
        Vector3 movedis = Camera.rotation * direction;
        moveDir = new Vector3(movedis.x, -GravityValue, movedis.z);
    }

    void Moving()     //플레이어 움직임만 구현
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

    void speedSet()     //속도구현
    {
        if(Input.GetKey(KeyCode.LeftControl) && CanCrouch)       //앉기
        {
            currentSpeed = CrouchSpeed;
        }
        else if(Input.GetKey(KeyCode.LeftShift) && CanSprint)    //달리기
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
