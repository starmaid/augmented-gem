using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public GameObject minPosObj;
    public GameObject maxPosObj;
    private Vector2 minPos;
    private Vector2 maxPos;

    // simply attach this to the camera object

    void Start(){
        transform.position = new Vector3 (target.position.x, target.position.y,transform.position.z);
        minPos = minPosObj.transform.position;
        maxPos = maxPosObj.transform.position;
        Debug.Log("minpos: " + minPos + "  maxpos: " + maxPos);
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
