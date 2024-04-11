using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughSystem : MonoBehaviour
{
    public Material transparentMaterial;
    public Material myMaterial;

    private bool isBehindWall = false;

    void Awake()
    {
        myMaterial = GetComponentInChildren<Renderer>().material;
    }

    void Update()
    {
        SetObjectTransparent();
    }

    public void SetObjectTransparent()
    {
        if (isBehindWall)
        {
            GetComponentInChildren<Renderer>().material = transparentMaterial;
        }
        else
        {
            GetComponentInChildren<Renderer>().material = myMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isBehindWall = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isBehindWall = false;
        }
    }
}
