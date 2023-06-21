using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void InGameScene()
    {
        StartCoroutine(delay2());
        
    }
    IEnumerator delay2() 
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("Out");          //Start
    }

    public void BackMain()
    {
        StartCoroutine(delay2Main());
    }
    IEnumerator delay2Main()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("MainMenu");          //Start
    }


    public void EndScene()
    {
        SceneManager.LoadScene("GG");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void sinwhanValorantNOOB()
    {
        Application.Quit();
    }



    private void Update()
    {
        if(DontDestory.photoCount == 7)
        {
            DontDestory.photoCount = 0;
            //EndScene();
        }
    }
}
