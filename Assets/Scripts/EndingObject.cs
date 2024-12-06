using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndingObject : MonoBehaviour
{
    [SerializeField] GameObject dungeon;
    [SerializeField] GameObject[] ceilings;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject ceiling in ceilings)
        {
            ceiling.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dungeon.transform.position.y > -302)
            dungeon.transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        else
        {
            dungeon.transform.position = new Vector3(0, -302, 0);
            gameObject.SetActive(false);
        }
    }
}
