using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void InGameScene()
    {

        SceneManager.LoadScene("INGAME");
    }

    public void EndScene()
    {
        SceneManager.LoadScene("ToB");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if(DontDestory.photoCount == 7)
        {
            DontDestory.photoCount = 0;
            EndScene();
        }
    }
}
