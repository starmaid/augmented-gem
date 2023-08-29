using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BooleanSO : ScriptableObject
{
    [SerializeField]
    private bool boolValue;
    public bool BoolValue
    {
        get { return boolValue; }
        set { boolValue = value; }
    }
    
}
