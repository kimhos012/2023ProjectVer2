using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBIOPEN : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.GetComponent<Open>().Opening();
        }
    }
}
