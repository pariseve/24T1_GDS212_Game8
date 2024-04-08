using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollection : MonoBehaviour
{
    public bool isHoldingItem = false;
    private bool isHoldingStardust = false;

    public GameObject offeringLocation;
    private bool isNearDeposit = false;

    public int stardustAmount = 0;
    public TextMeshProUGUI stardustText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isHoldingItem)
        {
            TryPickupItem();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isHoldingItem && isNearDeposit)
        {
            OfferItem();
        }
    }

    void TryPickupItem()
    {
        // Check for nearby items within the player's reach
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, 5f);
        foreach (Collider col in nearbyColliders)
        {
            if (col.CompareTag("Star"))
            {
                // If an item (star) is found, pick it up
                Destroy(col.gameObject); // Destroy the star GameObject
                isHoldingItem = true; // Set the flag to indicate the player is holding an item
                break; // Exit the loop after picking up the first item found
            }
        }
    }

    void OfferItem()
    {
        if (isHoldingItem && isNearDeposit)
        {
            // Give stardust to the player
            isHoldingItem = false; 
            isHoldingStardust = true; 
            Debug.Log("You offered the star and received stardust!");

            // Add stardust to the player's inventory
            AddStarDust();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == offeringLocation)
        {
            isNearDeposit = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == offeringLocation)
        {
            isNearDeposit = false;
        }
    }

    void AddStarDust()
    {
        stardustAmount += 10;

        stardustText.text = stardustAmount.ToString() + "%";
    }

}
