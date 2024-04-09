using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunctionHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent function;

    public void TriggerFunction()
    {
        function.Invoke();
    }
}
