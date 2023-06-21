using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuOption : MonoBehaviour
{
    bool toggle = false;
    public GameObject SaulJung;
    public GameObject MainUI;

    public void OptionToggle()
    {
        if (toggle) { toggle = false; }
        else { toggle = true; }
    }


    private void Update()
    {
        SaulJung.SetActive(toggle);
        MainUI.SetActive(!toggle);
    }

    void Start()
    {
        DontDestory.illgeeCount = 0;
        DontDestory.photoCount = 0;
    }
}
