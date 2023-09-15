using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ripped from tutorial
// https://www.youtube.com/watch?v=h-KOTKx_q2o
// https://forum.unity.com/threads/move-gameobject-along-a-given-path.455195/


public class PathObject : MonoBehaviour
{
    [HideInInspector]
    public GameObject ThingThatFollows;
    [HideInInspector]
    public float MoveSpeed;

    private float Timer;
    private float SegmentMoveSpeed;
    private static Vector3 StartPosition;
    private static Vector3 TargetPosition;

    private PathNode[] PathNodes;
    private int TargetNodeIndex;

    private bool paused;

    private Vector3 newPosition;
    private Vector3 delta;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
        PathNodes = GetComponentsInChildren<PathNode>();
        StartPosition = ThingThatFollows.transform.position;
        TargetPosition = PathNodes[0].transform.position;
        SegmentMoveSpeed = (TargetPosition - StartPosition).magnitude / MoveSpeed;

        // foreach (PathNode node in PathNodes)
        // {
        //     Debug.Log(node.name);
        // }

        //NextNode();
        paused = false;
    }

    void NextNode()
    {
        Timer = 0;
        StartPosition = TargetPosition;
        TargetPosition = PathNodes[TargetNodeIndex].transform.position;
        SegmentMoveSpeed = (TargetPosition - StartPosition).magnitude / MoveSpeed;
    }

    public void PauseMotion()
    {
        paused = true;
    }

    public void ResumeMotion()
    {
        paused=false;
    }

    // call this from the path follower object
    public Vector3 PathMoveUpdate()
    {
        delta = Vector3.zero;

        if (paused)
        {
            return delta;
        }

        Timer += Time.deltaTime;

        if (ThingThatFollows.transform.position != TargetPosition)
        {
            newPosition = Vector3.Lerp(StartPosition, TargetPosition, Timer / SegmentMoveSpeed);
            delta = newPosition - ThingThatFollows.transform.position;
            // move to the follower component
            //ThingThatFollows.transform.position = newPosition;
        } else
        {
            if (TargetNodeIndex < PathNodes.Length - 1)
            {
                TargetNodeIndex++;
            } else
            {
                TargetNodeIndex = 0;
            }

            NextNode();
        }

        return delta;
    }
}
