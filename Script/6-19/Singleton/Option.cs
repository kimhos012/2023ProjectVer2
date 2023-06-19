using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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
    [Range(-40f, 0f)]
    public float BGM_volume;

    [Tooltip("효과 소리")]
    [Range(-40f, 0f)]
    public float Effect_volume;

    [Space(10f)]
    [Tooltip("감도감도감도감도감도")]
    [Range(0.01f, 10f)]
    public float GAMDO;
    [Space(10f)]
    public int photo;
    public int daily;

    public AudioMixer audiomixer;
    //public AudioMixer sfxMixer;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Slider GamdoSlider;

    public void AudioControll()
    {
        BGMvol = bgmSlider.value;
        Effectvol = sfxSlider.value;

        if (BGMvol == -40f)
        {
            audiomixer.SetFloat("BGM", -80);
        }
        else
        {
            audiomixer.SetFloat("BGM", BGMvol);
        }

        if (Effectvol == -40f)
        {
            audiomixer.SetFloat("SFX", -80);
        }
        else
        {
            audiomixer.SetFloat("SFX", Effectvol);
        }
    }

    public void SensiControll()
    {
        sensitvity = GamdoSlider.value;
    }

    //---------------Code
    private void Start()
    {

        BGMvol = bgmSlider.value;
        Effectvol = sfxSlider.value;
        sensitvity = GamdoSlider.value;
    }
    

    private void Update()
    {
        photo = DontDestory.photoCount;
        daily = DontDestory.illgeeCount;

    }



}
