using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    public GameObject sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sound.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
    }
}
