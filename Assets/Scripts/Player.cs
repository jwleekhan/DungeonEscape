using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Key nearbyKey = null;
    [SerializeField] Gate nearbyGate = null;

    [SerializeField] bool[] hasKey;
    [SerializeField] int remainingGate = 4;
    [SerializeField] GameObject endingObject;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (nearbyKey)
            {
                Debug.Log("Get Key");
                hasKey[nearbyKey.fieldType] = true;
                nearbyKey.gameObject.SetActive(false);
                nearbyKey = null;
            }
            else if (nearbyGate)
            {
                if (nearbyGate.fieldType == 4) // Central Gate
                {
                    if (remainingGate <= 0)
                    {
                        Debug.Log("Open the Gate");
                        nearbyGate.gameObject.SetActive(false);
                        nearbyGate = null;
                    }
                    else
                    {
                        Debug.Log("Gate is Locked");
                    }
                }
                else
                {
                    if (hasKey[nearbyGate.fieldType])
                    {
                        Debug.Log("Open the Gate");
                        remainingGate--;
                        nearbyGate.pairGate.SetActive(false);
                        nearbyGate.gameObject.SetActive(false);
                        nearbyGate = null;
                    }
                    else
                    {
                        Debug.Log("Gate is Locked");
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            nearbyKey = other.GetComponent<Key>();
        }
        else if (other.tag == "Gate")
        {
            nearbyGate = other.GetComponent<Gate>();
        }
        else if (other.tag == "Ending")
        {
            other.gameObject.SetActive(false);
            endingObject.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Key")
        {
            nearbyKey = null;
        }
        else if (other.tag == "Gate")
        {
            nearbyGate = null;
        }
    }
}
