using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardGhostDisapper : MonoBehaviour
{
    public GameObject guardghost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.CompareTag("Player"))
        {
            guardghost.gameObject.SetActive(false);
        }
    }
}
