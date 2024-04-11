using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollection : MonoBehaviour
{
    public bool isHoldingItem = false;
    public bool isHoldingStardust = false;

    public GameObject offeringLocation;
    private bool isNearDeposit = false;

    public int stardustAmount = 0;
    public TextMeshProUGUI stardustText;

    private bool hasTriggeredDialogue = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isHoldingItem)
        {
            TryPickupItem();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isHoldingItem && isNearDeposit)
        {
            OfferItem();
        }
    }

    private void TryPickupItem()
    {
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, 5f);
        foreach (Collider col in nearbyColliders)
        {
            if (col.CompareTag("Star"))
            {
                Destroy(col.gameObject);
                isHoldingItem = true;
                break;
            }
        }
    }

    private void OfferItem()
    {
        if (isHoldingItem && isNearDeposit)
        {
            isHoldingItem = false;
            isHoldingStardust = true;
            Debug.Log("You offered the star and received stardust!");

            AddStarDust();

            if (!hasTriggeredDialogue)
            {
                DialogueStarter dialogueStarter = FindObjectOfType<DialogueStarter>();
                if (dialogueStarter != null)
                {
                    dialogueStarter.hasFollowedTutorial = true;
                    dialogueStarter.SecondDialogue();
                }
                hasTriggeredDialogue = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == offeringLocation)
        {
            isNearDeposit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == offeringLocation)
        {
            isNearDeposit = false;
        }
    }

    private void AddStarDust()
    {
        stardustAmount += 10;
        stardustText.text = stardustAmount.ToString();
    }

    public void RemoveStarDust()
    {
        stardustAmount -= 10;
        stardustText.text = stardustAmount.ToString();

        if (stardustAmount == 0)
        {
            isHoldingStardust = false;
        }
    }
}
