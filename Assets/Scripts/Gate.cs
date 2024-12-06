using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int fieldType; // 0: Grass, 1: Ice, 2: Fire, 3: Electric, 4: Central
    public GameObject pairGate;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void GateOpen()
    {
        pairGate.SetActive(false);

        switch (fieldType)
        {
            case 0:
                anim.SetTrigger("GrassOpen");
                break;
            case 1:
                anim.SetTrigger("IceOpen");
                break;
            case 2:
                anim.SetTrigger("FireOpen");
                break;
            case 3:
                anim.SetTrigger("ElectricOpen");
                break;
            default:
                break;
        }

        Invoke("SetActiveFalse", 1f);
    }

    void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
