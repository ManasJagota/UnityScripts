using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoints : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject Joystick;

    public bool triggered;
    void Awake()
    {
        triggered = false;
    }
    
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("trigger");
        // check we haven't been triggered yet!
        if (!triggered)
        {
           
            if (collider.gameObject.name == "Checkpoint")
            {
                Trigger();
                gameObject.SetActive(false);
            }
        }
    }
    void Trigger()
    {     
        triggered = true;
        button1.SetActive(true);
        button2.SetActive(true);    
        button3.SetActive(true);
        Joystick.SetActive(false);
    }
   
}
