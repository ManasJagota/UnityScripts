using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    public GameObject pickup;
    void OnTriggerEnter(Collider col)
    {
        pickup = GameObject.FindGameObjectWithTag("pickup");
        if(gameObject != null)
        {
            Destroy(gameObject);
                
              
            
        }
    }
}
