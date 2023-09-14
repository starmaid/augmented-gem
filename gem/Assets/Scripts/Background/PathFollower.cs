using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField]
    public PathObject path;
    public float MoveSpeed;

    public bool isActivelyFollowing;

    void Awake()
    {
        path.ThingThatFollows = gameObject;
        path.MoveSpeed = MoveSpeed;
    }

    public void StartFollowing()
    {
        isActivelyFollowing = true;
    }

    public void StopFollowing()
    {
        isActivelyFollowing = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivelyFollowing)
        {
            path.PathMoveUpdate();
        }
    }
}
