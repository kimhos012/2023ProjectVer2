using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughTrigger : MonoBehaviour
{
    public GameObject LaughSound;
    public GameObject ArmorerDoor;
    private Open ArmDoor;

    void Awake()
    {
        ArmDoor = ArmorerDoor.GetComponent<Open>();
    }

    void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.CompareTag("Player"))
        {
            LaughSound.GetComponent<AudioSource>().Play();
            ArmDoor.Opening();
            
            this.gameObject.SetActive(false);
        }
    }
}
