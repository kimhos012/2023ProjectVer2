using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class PlayerMenu : MonoBehaviour
{
    
    bool toggleMenu = false;            //false½Ã °ÔÀÓ ÁøÇà =  continue
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
            if (toggleMenu)
            {
                toggleMenu = false;
            }
            else if(!toggleMenu)
            {
                toggleMenu = true;
            }

            if (StartingGame)
                Openmenu();
            if(player.GetComponent<PlayerControllerWithCharC>().enabled)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        


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
            Cursor.visible = false;
            return;
        }
            
    }

    IEnumerator secMute()
    {
        player.GetComponent<AudioListener>().enabled = false;
        yield return new WaitForSecondsRealtime(0.2f);
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

    #region //Æ©Åä¸®¾ó
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
        player.GetComponent<PlayerControllerWithCharC>().enabled = true;        //¸Å¿ì ±ÍÂú´Ù
        InteractionUI.SetActive(true);
    }
    #endregion 

    [Space(20f)]
    public byte MaxPage = 7;
    public static byte DailyPage;
    byte PhotoPage;

    
    [Space(10f)]
    //public GameObject empty;
    public GameObject PageMoveSound;
   

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