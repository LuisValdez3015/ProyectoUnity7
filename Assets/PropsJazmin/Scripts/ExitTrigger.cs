using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent animaciones = default;

    private void OnDestroy()
    {       
        animaciones?.Invoke();
    }
}
