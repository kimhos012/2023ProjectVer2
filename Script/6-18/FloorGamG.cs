using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorGamG : MonoBehaviour
{
    public GameObject Display1f;
    public GameObject Display2f;
    public GameObject Displaybase;

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
                Displaybase.SetActive(true);
                break;
            case 1:
                Display1f.SetActive(true);

                break;

            case 2:
                Display2f.SetActive(true);

                break;
        }
        yield return new WaitForSecondsRealtime(2f);        //WaitDisplayMsg

        Display1f.SetActive(false);
        Display2f.SetActive(false);
        Displaybase.SetActive(false);

        yield return null;
    }
}
