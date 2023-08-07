using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    // https://www.youtube.com/watch?v=Lw3hNA5CkYY

    public SignalSO signalObject;
    public UnityEvent signalEvent;

    public void OnSignalRaised()
    {
        signalEvent.Invoke();
    }

    private void OnEnable()
    {
        signalObject.RegisterListener(this);
    }

    private void OnDisable()
    {
        signalObject.DeregisterListener(this);
    }
}
