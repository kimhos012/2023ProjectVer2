using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LookAtPlayer : MonoBehaviour
{
    public GameObject playerCam;
 
    // Start is called before the first frame update
    void Start()
    {
        //used to find the player object to look at
        //should be changed/altered depending on your project setup
        playerCam = GameObject.Find("PlayerCap");
    }
 
    // Update is called once per frame
    void LateUpdate()
    {
        //if there's a camera object correctly named
        if (playerCam != null)
        {
            GameObject lookPoint;
            lookPoint = playerCam;
 
            //look at the camera
            transform.LookAt(lookPoint.transform.position, -Vector3.up);
            //zeros out the Y rotation so the character doesn't look up/down
            //this can be removed depending on your needs
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        else
        {
            Debug.LogError("No camera found for look script! Double-check the object name is correct in the script");
        }
 
    }
 
}
