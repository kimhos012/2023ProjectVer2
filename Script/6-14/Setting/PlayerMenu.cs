using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    bool toggleMenu = false;
    public GameObject MenuUI;
    public GameObject BGM;
    public GameObject Cam;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           if(toggleMenu) { toggleMenu = false; }
           else if(!toggleMenu) { toggleMenu = true;}
        }

        if (!toggleMenu)
        {
            Time.timeScale = 1;
            MenuUI.SetActive(false);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            BGM.GetComponent<AudioSource>().UnPause();
        }
        else if(toggleMenu)
        {
            Time.timeScale = 0;
            MenuUI.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            BGM.GetComponent<AudioSource>().Pause();
        }
    }

    void Openmenu()
    {
        
    }

    //--------------------------- menu ----------------------------------
    public void SelectExit()
    {

    }

    public void WatchItem()
    {

    }

    public void Option()
    {

    }
}
