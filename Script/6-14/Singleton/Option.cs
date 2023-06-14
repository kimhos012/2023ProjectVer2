using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    //don't insert over 1 Object

    
    public static float BGMvol;
    public static float Effectvol;


    public static bool FloorSign;
    public static bool ShowInteraction;
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
    [Tooltip("층계 진입시, 알림")]
    public bool WatchFloorSignMessage;
    [Tooltip("아이템 줍기 UI")]
    public bool WatchInteractionMessage;
    [Tooltip("감도감도감도감도감도")]
    [Range(0.01f, 10f)]
    public float GAMDO;

    //---------------Code
    private void Start()
    {
        BGMvol = BGM_volume;            //Setting Dafault Option.
        Effectvol = Effect_volume;
        FloorSign = WatchFloorSignMessage;
        ShowInteraction = WatchInteractionMessage;
        sensitvity = GAMDO;
    }
}
