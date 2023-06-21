using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLight : MonoBehaviour
{
    public GameObject Fall;
    public GameObject Fallsound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Fall.GetComponent<Rigidbody>().useGravity = true;
            Fallsound.GetComponent<AudioSource>().Play();
        }
    }
}
