using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseComponent : MonoBehaviour
{
    [SerializeField]
    public float MoveSpeed;
    public bool isChasing;

    private GameObject chasedObject;

    private Animator _animator;

    private Vector3 trackingDelta;
    private Vector3 moveDelta;
    private PathFollower pfComponent;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
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
            trackingDelta = chasedObject.transform.position - gameObject.transform.position;
            moveDelta = (trackingDelta / trackingDelta.magnitude) * Time.deltaTime * MoveSpeed;
            gameObject.transform.position += moveDelta;

            // manage animator
            if (_animator != null)
            {
                _animator.SetFloat("moveX", moveDelta.x);
                _animator.SetFloat("moveY", moveDelta.y);
                _animator.SetBool("moving", true);
            }
        }
        else
        {
            if (_animator != null)
            {
                // the chase component and path follower are fighting over this value
                // just disabling it here, leaving it on in pathFollower
                //_animator.SetBool("moving", false);
            }
        }
    }
}
