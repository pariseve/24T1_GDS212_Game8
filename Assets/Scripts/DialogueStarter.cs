using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using cherrydev;

public class DialogueStarter : MonoBehaviour
{

    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private DialogNodeGraph introDialogue;

    [SerializeField] private UnityEvent triggerEvent;
    [SerializeField] private UnityEvent triggerEvent2;

    private void Start()
    {
        dialogBehaviour.BindExternalFunction("Test", DebugExternal);
        dialogBehaviour.BindExternalFunction("function1", Function);
        dialogBehaviour.BindExternalFunction("function2", Function2);

        dialogBehaviour.StartDialog(introDialogue);
    }

    private void DebugExternal()
    {
        Debug.Log("External function works!");
    }

    private void Function()
    {
        triggerEvent.Invoke();
    }

    private void Function2()
    {
        triggerEvent2.Invoke();
    }
}
