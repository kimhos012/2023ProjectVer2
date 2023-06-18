using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    //don't insert over 1 Object

    
    public static float BGMvol;
    public static float Effectvol;
    public static float sensitvity;


    //WIllbeUpdate
    public static bool ActiveLowGraphic;

    //----------------------Show In Inspector
    [Header("GameSetting")]
    [Space(20f)]

    [Header("Volume")]
    [Tooltip("배경 소리")]
    [Range(0f, 1f)]
    public float BGM_volume;

    [Tooltip("효과 소리")]
    [Range(0f, 1f)]
    public float Effect_volume;

    [Space(10f)]
    [Tooltip("감도감도감도감도감도")]
    [Range(0.01f, 10f)]
    public float GAMDO;

    //---------------Code
    private void Start()
    {
        BGMvol = BGM_volume;            //Setting Dafault Option.
        Effectvol = Effect_volume;
        sensitvity = GAMDO;
    }
    [Space(10f)]
    public int photo;
    public int daily;


    private void Update()
    {
        photo = DontDestory.photoCount;
        daily = DontDestory.illgeeCount;
    }

}
