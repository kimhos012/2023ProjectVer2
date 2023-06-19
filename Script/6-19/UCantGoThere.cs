using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCantGoThere : MonoBehaviour
{
    
    public GameObject Barrier2f;
    public GameObject BarrierBase;

    private void Update()
    {
        if (DontDestory.photoCount > 2 && DontDestory.illgeeCount > 2)        //2f iz open
        {
            Barrier2f.SetActive(false);
        }
        else
        {
            Barrier2f.SetActive(true);
        }
        if (DontDestory.photoCount > 5 && DontDestory.illgeeCount > 5)
        {
            BarrierBase.SetActive(false);
        }
        else
        {
            BarrierBase.SetActive(true);
        }
    }
}
