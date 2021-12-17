using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventoDeTriggers : MonoBehaviour
{
    [SerializeField] public EventoDeTriggers[] triggerNeeded = default;
    [SerializeField] public UnityEvent onTriggered = default;

    public bool WasTriggered { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (WasTriggered) return;
        if (RequiredTriggers()) return;

        WasTriggered = true;
        onTriggered.Invoke();

    }

    private bool RequiredTriggers()
    {
        for (int i = 0; i < triggerNeeded.Length; i++)
        {
            if (!triggerNeeded[i].WasTriggered)
                return false;
        }

        return true;
    }
}
