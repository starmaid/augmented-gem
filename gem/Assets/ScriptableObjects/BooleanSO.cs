using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BooleanSO : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    public bool initialValue;
    public bool defaultValue;

    public void OnAfterDeserialize()
    {
        initialValue=defaultValue;
    }

    public void OnBeforeSerialize()
    {
    }
    
}
