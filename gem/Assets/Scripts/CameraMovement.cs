using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    // simply attach this to the camera object
    void LateUpdate()
    {
        Vector3 targetPos = new Vector3 (target.transform.position.x,target.transform.position.y,transform.position.z);
        if (transform.position != targetPos){
            transform.position = Vector3.Lerp(transform.position,targetPos,smoothing); //linear interpolation 
        }
    }
}
