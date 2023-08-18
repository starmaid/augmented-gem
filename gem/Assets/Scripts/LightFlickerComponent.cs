using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class flicker : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 10f)]
    public float lfoAmplitude = 1.0f;
    [Range(0.1f, 10f)]
    public float lfoRate = 0.8f;
    [Range(0.1f, 10f)]
    public float spikesAmplitude = 1.0f;

    private float setIntensity;


    private Light2D l;

    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<Light2D>();
        
        if (l != null ) 
        { 
            setIntensity = l.intensity;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (l != null)
        {
            l.intensity = setIntensity 
                + lfoAmplitude * math.sin(Time.realtimeSinceStartup * lfoRate) 
                + UnityEngine.Random.Range(0, spikesAmplitude);
        }
    }
}
