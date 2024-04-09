using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurifySystem : MonoBehaviour
{
    ItemCollection itemCollection;

    public GameObject originalObjPrefab;
    //public GameObject newObjPrefab;

    public bool isPure = false;
    private bool hasEnteredArea = false;

    void Awake()
    {
        itemCollection = FindObjectOfType<ItemCollection>();
        if (itemCollection == null)
        {
            Debug.LogWarning("ItemCollection component not found in the scene!");
        }
    }

    private void Update()
    {
        // checks multiple times for the input (instead of only checking once on the trigger enter part
        if (itemCollection.isHoldingStardust && !isPure && Input.GetKeyDown(KeyCode.Space) && hasEnteredArea) 
        {
            Debug.Log("The area has been purified!");
            isPure = true;

            itemCollection.RemoveStarDust();
            originalObjPrefab.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasEnteredArea = true;
            Debug.Log("Player detected!");

          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has left area");
            hasEnteredArea = false;
        }
    }


}

