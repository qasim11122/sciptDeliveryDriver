using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToFollow : MonoBehaviour
{
    [SerializeField] GameObject thingtofollow;
   
    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = thingtofollow.transform.position + new Vector3(0,0,-10);
            
    }
}