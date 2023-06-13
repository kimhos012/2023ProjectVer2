using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorGamG : MonoBehaviour
{
    public Text kimdohyunisreallyamazinguy;
    public sbyte floor;

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(viewMsg());
    }

    IEnumerator viewMsg()
    {
        switch(floor)
        {
            case -1:
                kimdohyunisreallyamazinguy.text = "ÁöÇÏ";
                break;
            case 1:
                kimdohyunisreallyamazinguy.text = "1F";
                break;

            case 2:
                kimdohyunisreallyamazinguy.text = "2Ãþ";
                break;
        }
        yield return new WaitForSecondsRealtime(2f);        //WaitDisplayMsg

        kimdohyunisreallyamazinguy.text = "";

        yield return null;
    }
}
