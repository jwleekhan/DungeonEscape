using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int fieldType; // 0: Grss, 1: Ice, 2: Fire, 3: Electric
    [SerializeField] int rotateSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }
}
