using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField]
    public PathObject path;
    public float MoveSpeed;

    public bool isActivelyFollowing;

    private Vector3 newPosition;
    private Vector3 deltaPosition;

    private Animator _animator;
    private AudioSource _myAudioSource;

    void Awake()
    {
        path.ThingThatFollows = gameObject;
        path.MoveSpeed = MoveSpeed;
        _animator = GetComponent<Animator>();
        _myAudioSource = GetComponent<AudioSource>();
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

    void PlayWalkSound()
    {
        if (_myAudioSource != null)
        {
            _myAudioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivelyFollowing)
        {
            deltaPosition = path.PathMoveUpdate();
            gameObject.transform.position += deltaPosition;

            // manage animator
            if (_animator != null)
            {
                _animator.SetFloat("moveX", deltaPosition.x);
                _animator.SetFloat("moveY", deltaPosition.y);
                _animator.SetBool("moving", true);
            }
        } else
        {
            if (_animator != null)
            {
                _animator.SetBool("moving", false);
            }
        }
    }
}
