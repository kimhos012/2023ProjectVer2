using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    
    public bool toggleMenu = false;            //false시 게임 진행 =  continue
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
    
    




    private void Update()
    {
        //DirectDiary();

        if (player.GetComponent<PlayerControllerWithCharC>().enabled)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        GetEsc();
        detect7();

    }


    void GetEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (toggleMenu)
            {
                toggleMenu = false;
                if (StartingGame)
                    Openmenu();
            }
            else if (!toggleMenu)
            {
                toggleMenu = true;
                if (StartingGame)
                    Openmenu();
            }
        }
    }
        //--------------------------------------------DetectEnd----------------------------------------------------------

    private void Start()
    {

        if (SceneManager.GetActiveScene().name == "Out")
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
        if (SceneManager.GetActiveScene().name == "OutSideToEnding")
        {
            MaZza.SetActive(false);
            blackscreen.SetActive(false);
            MyGgaKillHatDa.SetActive(false);
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
        else if (toggleMenu)            //메뉴켜기
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

    int SaveD = 0;
    public void DirectDiary()
    {
        if(DontDestory.illgeeCount != SaveD)
        {
            toggleMenu = true;
            MenuUI.SetActive(false);
            UI_Daily();
            SaveD = DontDestory.illgeeCount;
        }
        else
        { return; }
    }

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
        pagesound();
    }

    public void UI_Daily()
    {
        DailyUI.SetActive(true);
        MenuUI.SetActive(false);
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

    public Image FadeObj;

    public void T_exit()
    {
        T_gameobj.SetActive(false);
        StartingGame = true;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(In());
        player.GetComponent<PlayerControllerWithCharC>().enabled = true;        //매우 귀찮다
        InteractionUI.SetActive(true);
    }
    #endregion 

    public IEnumerator In()         //from "Fade.cs"
    {
        float Count = 1.0f;
        while (Count > 0f)
        {
            Count -= 0.01f;
            yield return new WaitForSecondsRealtime(.01f);
            FadeObj.color = new Color(0, 0, 0, Count);
        }
        yield return null;
    }

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

    //엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩엔딩

    bool endcounter = false;
    [Space(10f)]
    public GameObject MaZza;
    public GameObject blackscreen;
    public GameObject MyGgaKillHatDa;
    public GameObject endBGM;


    void detect7()
    {
        if (SceneManager.GetActiveScene().name == "OutSideToEnding")
        {
            if (DontDestory.illgeeCount == 7 && DontDestory.photoCount >= 7)
            {
                endcounter = true;
            }
            if (endcounter && PhotoUI.activeSelf == false)
            {
                StartCoroutine(GoToEnd());
                endcounter = false;
                DontDestory.illgeeCount = 8;
            }
        }
    }

    IEnumerator GoToEnd()       //엔딩보여주기 절반
    {
        player.GetComponent<PlayerControllerWithCharC>().enabled = false;
        yield return new WaitForSecondsRealtime(2f);
        pagesound();
        yield return new WaitForSecondsRealtime(4f);
        endBGM.GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(4.0f);
        toggleMenu = false;
        MaZza.SetActive(true);
        yield return new WaitForSecondsRealtime(3.0f);

        MaZza.SetActive(false);
        yield return new WaitForSecondsRealtime(3.0f);

        blackscreen.SetActive(true);
        endBGM.GetComponent <AudioSource>().Stop();
        yield return new WaitForSecondsRealtime(1f);

        MyGgaKillHatDa.SetActive(true);
        yield return new WaitForSecondsRealtime(3.0f);

        MyGgaKillHatDa.SetActive(false);
        yield return new WaitForSecondsRealtime(.5f);

        SceneManager.LoadScene("GG");
    }
}