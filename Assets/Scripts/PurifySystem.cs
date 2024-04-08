using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurifySystem : MonoBehaviour
{
    ItemCollection itemCollection;

    public GameObject originalObjPrefab;
    public GameObject newObjPrefab;

    public bool isPure = false;

    void Awake()
    {
        itemCollection = FindObjectOfType<ItemCollection>();
        if (itemCollection == null)
        {
            Debug.LogWarning("ItemCollection component not found in the scene!");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected!");

            if (itemCollection.isHoldingStardust) // adding && Input.GetKeyDown(KeyCode.Space) breaks everything ??
            {
                Debug.Log("The area has been purified!");
                isPure = true;

                itemCollection.RemoveStarDust();
            }
            else
            {
                Debug.Log("Player has no stardust");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has left area");
        }
    }


}

