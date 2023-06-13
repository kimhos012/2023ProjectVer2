using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{

    public static byte photoCount;
    public static byte illgeeCount;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
