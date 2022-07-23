using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Rigidbody Car;

    public Text speedomet;
    private float speed = 0.0f;
    
    // Update is called once per frame
    void Update()
    {
        speed = Car.velocity.magnitude * 3.6f;
        if(speedomet!=null)
        {
            speedomet.text = ((int)speed) + "km/h";
        }
    }
}
