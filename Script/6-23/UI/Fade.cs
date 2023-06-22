using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    public Image FadeObj;


    public void Fadeout()
    {
        StartCoroutine(Out());
    }
    public void Fadein()
    {
        StartCoroutine(In());
    }

    public IEnumerator Out()            //어두워지기
    {
        float Count = 0;
        while(Count < 1.0f)
        {
            Count += 0.01f;
            yield return new WaitForSecondsRealtime(.01f);
            FadeObj.color = new Color(0, 0, 0, Count);
        }
        yield return null;
    }

    public IEnumerator In()         //밝아지기
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


}
