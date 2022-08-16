using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject joystick;

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
                gameObject.SetActive(false);
                joystick.SetActive(false);
                Trigger();
            }
        }
    }
    void Trigger()
    {
        triggered = true;
        panel.SetActive(true);
    }
}
