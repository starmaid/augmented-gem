using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ripped from tutorial
// https://www.youtube.com/watch?v=h-KOTKx_q2o
// https://forum.unity.com/threads/move-gameobject-along-a-given-path.455195/


public class PathFollower : MonoBehaviour
{
    [SerializeField]
    public GameObject ThingThatFollows;
    public float MoveSpeed;

    private float Timer;
    private float SegmentMoveSpeed;
    private static Vector3 StartPosition;
    private static Vector3 TargetPosition;

    private PathNode[] PathNodes;
    private int TargetNodeIndex;

    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        PathNodes = GetComponentsInChildren<PathNode>();
        StartPosition = ThingThatFollows.transform.position;

        // foreach (PathNode node in PathNodes)
        // {
        //     Debug.Log(node.name);
        // }

        NextNode();
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

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            return;
        }

        Timer += Time.deltaTime;

        if (ThingThatFollows.transform.position != TargetPosition)
        {
            ThingThatFollows.transform.position = Vector3.Lerp(StartPosition, TargetPosition, Timer / SegmentMoveSpeed);
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
    }
}
