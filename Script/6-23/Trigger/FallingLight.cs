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
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        Fall.GetComponent<Rigidbody>().useGravity = true;
        Fallsound.GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(1.0f);
        gameObject.SetActive(false);
    }
}
