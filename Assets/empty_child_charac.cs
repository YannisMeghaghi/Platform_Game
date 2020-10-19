using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empty_child_charac : MonoBehaviour
{
    public GameObject charac;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            charac.SendMessage("Init_Ground_True");
        }
    }

    void OnTriggerExit(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            charac.SendMessage("Init_Ground_False");
        }
    }
}
