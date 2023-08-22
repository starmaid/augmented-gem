using System.Collections;
using System.Collections.Generic;
using SuperTiled2Unity.Editor;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 minPos;
    public Vector2 maxPos;

    // simply attach this to the camera object

    void Start(){
        transform.position = new Vector3 (target.position.x, target.position.y,transform.position.z);
        minPos = transform.Find("minPos").position;
        maxPos = transform.Find("maxPos").position;
    }

    void LateUpdate()
    {    
        if (transform.position != target.position){
            Vector3 targetPos = new Vector3 (target.transform.position.x,
                                            target.transform.position.y,
                                            transform.position.z);
            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);   
            transform.position = Vector3.Lerp(transform.position,targetPos,smoothing); //linear interpolation 
        }
    }
}
