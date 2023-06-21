using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class lighting : MonoBehaviour
{

    public GameObject Light;
    public GameObject lightSound;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FlickingLight());
        }
    }

    IEnumerator FlickingLight()
    {
        int appleRandom;
        appleRandom = Random.Range(1, 20);

        for (int i = 0; i < appleRandom; i++)
        {
            Light.SetActive(true);
            lightSound.GetComponent<AudioSource>().Play();
            yield return new WaitForSecondsRealtime(.02f);
            Light.SetActive(false);
        }
        Light.SetActive(false);
        gameObject.SetActive(false);

        yield return null;
    }

}
