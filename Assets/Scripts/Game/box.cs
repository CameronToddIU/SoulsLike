using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Box"))
        {
            Debug.Log("hello");
            other.GetComponent<Doors>().Test2(true);
        } 
    }
}
