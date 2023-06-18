using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenu : MonoBehaviour
{
    
    bool toggleMenu = false;            //false시 게임 진행 =  continue
    bool IsNextPage;
    private bool StartingGame;
    

    public GameObject MenuUI;
    public GameObject OptionUI;
    public GameObject PhotoUI;
    public GameObject DailyUI;

    [Space(10f)]
    public GameObject BGM;
    public GameObject player;

    [Space(10f)]
    public GameObject InteractionUI;
    public GameObject T_gameobj;
    [Space(10f)]
    public GameObject MyGgaKillHatDa;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           if(toggleMenu) { toggleMenu = false; }
           else if(!toggleMenu) { toggleMenu = true;}

            if (StartingGame)
                Openmenu();
        }
        ViewDailyPhoto();
        //--------------------------------------------DetectEnd----------------------------------------------------------

        if(DontDestory.illgeeCount >= 7 && DontDestory.photoCount >= 7 && DailyUI.activeSelf)
        {
            Debug.Log("omg sans");
        }
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Out")
        {
            StartingGame = false;
            IsNextPage = true;
            T_gameobj.SetActive(true);
            T_next();
            player.GetComponent<PlayerControllerWithCharC>().enabled = false;
        }
        else
        {
            StartingGame = true;
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
            
    }

    IEnumerator secMute()
    {
        player.GetComponent<AudioListener>().enabled = false;
        yield return new WaitForSecondsRealtime(1f);
        player.GetComponent<AudioListener>().enabled = true;
    }

    void Openmenu()
    {
        if (!toggleMenu)
        {
            //Time.timeScale = 1;
            MenuUI.SetActive(false);
            InteractionUI.SetActive(true);

            player.GetComponent<PlayerControllerWithCharC>().enabled = true;

            BGM.GetComponent<AudioSource>().UnPause();

            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (toggleMenu)
        {
            //Time.timeScale = 0;
            MenuUI.SetActive(true);
            InteractionUI.SetActive(false);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            player.GetComponent<PlayerControllerWithCharC>().enabled = false;

            BGM.GetComponent<AudioSource>().Pause();
        }
    }

    //---------------------------UI click----------------------------------

    

    public void Continue()
    {
        toggleMenu = false;
        Openmenu();
    }

    public void Back2Menu()
    {
        OptionUI.SetActive(false);
        PhotoUI.SetActive(false);
        DailyUI.SetActive(false);

        MenuUI.SetActive(true);
    }

    public void UI_Option()
    {
        MenuUI.SetActive(false);
        OptionUI.SetActive(true);
    }

    public void UI_Photo()
    {
        MenuUI.SetActive(false);
        PhotoUI.SetActive(true);
    }

    public void UI_Daily()
    {
        MenuUI.SetActive(false);
        DailyUI.SetActive(true);
        pagesound();
    }

    #region //튜토리얼
    public void T_next()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if(IsNextPage)
        {
            IsNextPage = false;
            T_gameobj.transform.GetChild(1).gameObject.SetActive(true);
            T_gameobj.transform.GetChild(2).gameObject.SetActive(false) ;

        }
        else
        {
            IsNextPage = true;
            T_gameobj.transform.GetChild(1).gameObject.SetActive(false);
            T_gameobj.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public void T_exit()
    {
        T_gameobj.SetActive(false);
        StartingGame = true;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<PlayerControllerWithCharC>().enabled = true;        //매우 귀찮다
        InteractionUI.SetActive(true);
    }
    #endregion 

    [Space(20f)]
    public byte MaxPage = 7;
    byte DailyPage;
    byte PhotoPage;

    //일지 이미지 지정
    public GameObject Daily1;
    public GameObject Daily2;
    public GameObject Daily3;
    public GameObject Daily4;
    public GameObject Daily5;
    public GameObject Daily6;
    public GameObject Daily7;

    
    [Space(10f)]
    public GameObject empty;
    public GameObject PageMoveSound;

    [Space(10f)]
    public GameObject Photo;

    void ViewDailyPhoto()           
    {
        if(DontDestory.illgeeCount != 0)        //Daily
        {
            DailyPage = 1;
        }
        switch (DailyPage)
        {

            case 1:
                if (DontDestory.illgeeCount >= 1)
                {
                    empty.SetActive(false);
                    Daily1.SetActive(true);
                    Daily2.SetActive(false);
                    Daily3.SetActive(false);
                    Daily4.SetActive(false);
                    Daily5.SetActive(false);
                    Daily6.SetActive(false);
                    Daily7.SetActive(false);
    
                }
                break;
            case 2:
                if (DontDestory.illgeeCount >= 2)
                {
                    empty.SetActive(false);
                    Daily1.SetActive(false);
                    Daily2.SetActive(true);
                    Daily3.SetActive(false);
                    Daily4.SetActive(false);
                    Daily5.SetActive(false);
                    Daily6.SetActive(false);
                    Daily7.SetActive(false);
    
                }
                break;
            case 3:
                if (DontDestory.illgeeCount >= 3)
                {
                    empty.SetActive(false);
                    Daily1.SetActive(false);
                    Daily2.SetActive(false);
                    Daily3.SetActive(true);
                    Daily4.SetActive(false);
                    Daily5.SetActive(false);
                    Daily6.SetActive(false);
                    Daily7.SetActive(false);
    
                }
                break;
            case 4:
                if (DontDestory.illgeeCount >= 4)
                {
                    empty.SetActive(false);
                    Daily1.SetActive(false);
                    Daily2.SetActive(false);
                    Daily3.SetActive(false);
                    Daily4.SetActive(true);
                    Daily5.SetActive(false);
                    Daily6.SetActive(false);
                    Daily7.SetActive(false);
       
                }
                break;
            case 5:
                if (DontDestory.illgeeCount >= 5)
                {
                    empty.SetActive(false);
                    Daily1.SetActive(false);
                    Daily2.SetActive(false);
                    Daily3.SetActive(false);
                    Daily4.SetActive(false);
                    Daily5.SetActive(true);
                    Daily6.SetActive(false);
                    Daily7.SetActive(false);
                }
                break;
            case 6:
                if (DontDestory.illgeeCount >= 6)
                {
                    empty.SetActive(false);
                    Daily1.SetActive(false);
                    Daily2.SetActive(false);
                    Daily3.SetActive(false);
                    Daily4.SetActive(false);
                    Daily5.SetActive(false);
                    Daily6.SetActive(true);
                    Daily7.SetActive(false);
                }
                break;
            case 7:
                if (DontDestory.illgeeCount >= 7)
                {
                    empty.SetActive(false);
                    Daily1.SetActive(false);
                    Daily2.SetActive(false);
                    Daily3.SetActive(false);
                    Daily4.SetActive(false);
                    Daily5.SetActive(false);
                    Daily6.SetActive(false);
                    Daily7.SetActive(true);
                }
                break;
            case 0:
                Daily1.SetActive(false);
                Daily2.SetActive(false);
                Daily3.SetActive(false);
                Daily4.SetActive(false);
                Daily5.SetActive(false);
                Daily6.SetActive(false);
                Daily7.SetActive(false);
                empty.SetActive(true);
                break;
            default:
                break;
        }

        //Photo Display

        switch(DontDestory.photoCount)
        {
            case 0:
                Photo.transform.GetChild(0).gameObject.SetActive(true);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);
                Photo.transform.GetChild(7).gameObject.SetActive(false);

                break;
            case 1:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(true);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);
                Photo.transform.GetChild(7).gameObject.SetActive(false);

                break;
            case 2:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(true);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);
                Photo.transform.GetChild(7).gameObject.SetActive(false);

                break;
            case 3:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(true);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);
                Photo.transform.GetChild(7).gameObject.SetActive(false);

                break;
            case 4:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(true);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);
                Photo.transform.GetChild(7).gameObject.SetActive(false);

                break;
            case 5:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(true);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);
                Photo.transform.GetChild(7).gameObject.SetActive(false);

                break;
            case 6:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(true);
                Photo.transform.GetChild(7).gameObject.SetActive(false);

                break;
            case 7:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);
                Photo.transform.GetChild(7).gameObject.SetActive(true);

                break;
            default: break;
        }
    }

    void pagesound()
    {
        int randomsound;
            randomsound = Random.Range(1, 4);
            switch (randomsound)
            {
                case 1:
                    PageMoveSound.transform.GetChild(0).GetComponent<AudioSource>().Play();
                    break;
                case 2:
                    PageMoveSound.transform.GetChild(1).GetComponent<AudioSource>().Play();
                    break;
                case 3:
                    PageMoveSound.transform.GetChild(2).GetComponent<AudioSource>().Play();
                    break;
                default: break;
            }
    }

    public void NextPage()
    {
         if(DailyPage < MaxPage && DontDestory.illgeeCount > DailyPage)
        {
            DailyPage++;
            pagesound();
        }
    }

    public void PreviousPage()
    {
        if(DailyPage > 1)
        {
            DailyPage--;
            pagesound();
        }
    }
}