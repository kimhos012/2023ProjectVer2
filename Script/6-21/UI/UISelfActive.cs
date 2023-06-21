using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelfActive : MonoBehaviour
{
    public bool imEnable;

    private void OnEnable()
    {
        imEnable = true;
    }
    private void OnDisable()
    {
        imEnable = false;
    }

}
