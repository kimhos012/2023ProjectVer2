using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GEAZIMglass : MonoBehaviour
{
    public GameObject nonBreak;
    public GameObject brokenGlass;
    public GameObject GlassSound;

    bool illWhaeYoung;

    private void Start()
    {
        brokenGlass.SetActive(false);
        nonBreak.SetActive(true);
    }

    private void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !illWhaeYoung)
        {
            illWhaeYoung = true;
            GlassSound.GetComponent<AudioSource>().Play();
            brokenGlass.SetActive(true);
            nonBreak?.SetActive(false);
        }
    }
}
