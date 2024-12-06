using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Key nearbyKey = null;
    [SerializeField] Gate nearbyGate = null;

    [SerializeField] bool[] hasKey;
    [SerializeField] int remainingGate = 4;
    [SerializeField] GameObject endingObject;

    void Start()
    {
        transform.position = new Vector3(-45.5f, 0, -145.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameManager.PanelActive())
            {
                gameManager.ClosePanel();
            }
            else
            {
                if (nearbyGate)
                {
                    if (nearbyGate.fieldType == 4) // Central Gate
                    {
                        if (remainingGate <= 0)
                        {
                            nearbyGate.gameObject.SetActive(false);
                            nearbyGate = null;
                        }
                        else
                        {
                            gameManager.DisplayTextPanel("열리지 않는다.");
                        }
                    }
                    else
                    {
                        if (hasKey[nearbyGate.fieldType])
                        {
                            remainingGate--;
                            nearbyGate.GateOpen();
                            nearbyGate = null;

                            if (remainingGate <= 0)
                            {
                                gameManager.AllGateOpened();
                            }
                        }
                        else
                        {
                            gameManager.DisplayTextPanel("열리지 않는다.");
                        }
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
            gameManager.DisplayTextPanel("열쇠를 획득했다.");
            hasKey[nearbyKey.fieldType] = true;
            nearbyKey.gameObject.SetActive(false);
            nearbyKey = null;
        }
        else if (other.tag == "Gate")
        {
            nearbyGate = other.GetComponent<Gate>();
        }
        else if (other.tag == "Ending")
        {
            other.gameObject.SetActive(false);
            endingObject.gameObject.SetActive(true);
            gameManager.DisplayClear();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gate")
        {
            nearbyGate = null;
        }
    }
}
