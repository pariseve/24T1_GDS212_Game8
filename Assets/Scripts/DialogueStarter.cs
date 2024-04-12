using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using cherrydev;

public class DialogueStarter : MonoBehaviour
{

    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private DialogNodeGraph introDialogue;
    [SerializeField] private DialogNodeGraph introDialogue2;

    [SerializeField] private UnityEvent triggerEvent;
    [SerializeField] private UnityEvent triggerEvent2;
    [SerializeField] private UnityEvent triggerEvent3;

    EndingTrigger ending;

    public GameObject tutorialStar;

    [SerializeField] ItemCollection itemCollection;
    public bool hasFollowedTutorial = false;

    private void Start()
    {
        itemCollection = FindObjectOfType<ItemCollection>();
        if (itemCollection == null)
        {
            Debug.LogError("ItemCollection reference not found!");
            return;
        }

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

    private void Function3()
    {
        triggerEvent3.Invoke();
    }

    public void SecondDialogue()
    {
        if (hasFollowedTutorial)
        {
            Debug.Log("Triggered Second Dialogue!");
            dialogBehaviour.BindExternalFunction("Test", DebugExternal);
            dialogBehaviour.BindExternalFunction("function1", Function);
            dialogBehaviour.BindExternalFunction("function2", Function2);
            dialogBehaviour.StartDialog(introDialogue2);
        }
        else
        {
            Debug.Log("Second dialogue condition not met!");
        }
    }

    public void FinalDialogue()
    {
        if (hasFollowedTutorial)
        {
            Debug.Log("Triggered Second Dialogue!");
            dialogBehaviour.BindExternalFunction("Test", DebugExternal);
            dialogBehaviour.BindExternalFunction("function1", Function);
            dialogBehaviour.BindExternalFunction("function2", Function2);
            dialogBehaviour.StartDialog(introDialogue2);
        }
        else
        {
            Debug.Log("Second dialogue condition not met!");
        }
    }

}
