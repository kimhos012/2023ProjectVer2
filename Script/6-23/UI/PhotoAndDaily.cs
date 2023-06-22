using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PhotoAndDaily : MonoBehaviour
{
    [Space(20f)]
    public byte MaxPage = 7;
    byte PhotoPage;

    public GameObject Daily1;
    public GameObject Daily2;
    public GameObject Daily3;
    public GameObject Daily4;
    public GameObject Daily5;
    public GameObject Daily6;
    public GameObject Daily7;
    [Space(10f)]
    public Image Daily7Copy;
    public Image LastDaily;
    public GameObject KauSheen;

    [Space(10f)]
    public GameObject empty;

    [Space(10f)]
    public GameObject Photo;


    private void Update()
    {
        ViewDailyPhoto();
        if(DontDestory.illgeeCount >= 7 && DontDestory.photoCount >= 7)
        {
            ChangePhoto();
        }
    }

    void ViewDailyPhoto()
    {
        if (DontDestory.illgeeCount == 0)        //Daily
        {
            PlayerMenu.DailyPage = 0;
        }
        else if(DontDestory.illgeeCount == 1)
        {
            PlayerMenu.DailyPage = 1;
        }
        switch (PlayerMenu.DailyPage)
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

        switch (DontDestory.photoCount)
        {
            case 0:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);

                break;
            case 1:
                Photo.transform.GetChild(0).gameObject.SetActive(true);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);

                break;
            case 2:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(true);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);

                break;
            case 3:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(true);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);

                break;
            case 4:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(true);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);

                break;
            case 5:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(true);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(false);

                break;
            case 6:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(true);
                Photo.transform.GetChild(6).gameObject.SetActive(false);

                break;
            case 7:
                Photo.transform.GetChild(0).gameObject.SetActive(false);
                Photo.transform.GetChild(1).gameObject.SetActive(false);
                Photo.transform.GetChild(2).gameObject.SetActive(false);
                Photo.transform.GetChild(3).gameObject.SetActive(false);
                Photo.transform.GetChild(4).gameObject.SetActive(false);
                Photo.transform.GetChild(5).gameObject.SetActive(false);
                Photo.transform.GetChild(6).gameObject.SetActive(true);

                break;
            default: break;
        }
    }
    bool no = true;
    public void ChangePhoto()
    {
        if(no)
            StartCoroutine(a1());
            no = false;
    }
    IEnumerator a1()                //다른 방법이 있지만 시간이...
    {
        float alpha = 0f;
        while(alpha < 1.0f)
        {
            Daily7Copy.color = new Color(1, 1, 1, alpha);
            alpha += 0.1f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        yield return new WaitForSecondsRealtime(2f);
        alpha = 0f;
        while(alpha < 1.0f)
        {
            alpha += 0.1f;
            LastDaily.color = new Color(1, 1, 1, alpha);
            Daily7Copy.color = new Color(1, 1, 1, (1 - alpha));
            yield return new WaitForSecondsRealtime(.05f);
        }
        yield return new WaitForSecondsRealtime(4.0f);
        KauSheen.SetActive(true);
        yield return new WaitForSecondsRealtime(3.0f);
        KauSheen.SetActive(false);

        while (alpha > 0f)
        {
            alpha -= 0.1f;
            LastDaily.color = new Color(1, 1, 1, alpha);
            yield return new WaitForSecondsRealtime(.01f);
        }
        yield return null;
    }

}
