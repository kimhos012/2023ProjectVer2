using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    bool toggleMenu;
    public GameObject MenuUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(toggleMenu)
            {
                toggleMenu = false;
                Time.timeScale = 1;
                MenuUI.SetActive(false);
            }
            else
            {
                toggleMenu = true;      //OpenEscapeMenu
                Time.timeScale = 0;
                MenuUI.SetActive(true);
            }
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
