using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseComponent : MonoBehaviour
{
    [SerializeField]
    public float MoveSpeed;
    public bool isChasing;

    private GameObject chasedObject;
    

    private Vector3 v;
    private PathFollower pfComponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartChase(GameObject tryChasedObject)
    {
        if (tryChasedObject == null) { return; }
        chasedObject = tryChasedObject;
        isChasing = true;

        pfComponent = gameObject.GetComponent<PathFollower>();

        if (pfComponent != null)
        {
            pfComponent.StopFollowing();
        }
    }

    public void StopChase()
    {
        isChasing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            v = chasedObject.transform.position - gameObject.transform.position;
            gameObject.transform.position += (v / v.magnitude) * Time.deltaTime * MoveSpeed;
        }
    }
}
