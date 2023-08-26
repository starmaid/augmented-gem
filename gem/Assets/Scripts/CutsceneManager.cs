using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    public Animator playerAnimator;
    public RuntimeAnimatorController playerAnim;
    public PlayableDirector director;

    // Start is called before the first frame update
    public void Pause()
    {
        Debug.Log("attempted pause");
        director.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }

    // Update is called once per frame
    public void Resume()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
}
