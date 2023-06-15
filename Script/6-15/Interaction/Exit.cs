using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour
{
    public bool ExitDoor;       //detect door ½Ã¹ß


    private void Start()
    {
    }

    public void OnExit()
    {
        if (ExitDoor)
        {
            SceneManager.LoadScene("OutSideToEnding");
        }
        else
        {
            SceneManager.LoadScene("INGAME");
        }
    }
}
