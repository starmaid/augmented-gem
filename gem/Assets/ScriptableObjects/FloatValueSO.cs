using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValueSO : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;
    public float defaultValue;


    public void OnAfterDeserialize()
    {
        initialValue=defaultValue;
    }

    public void OnBeforeSerialize()
    {
    }
}
