using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;         //To get information about the basic axle which store information about control
    public float Torque;                     // To give torque or provide force for movement
    public float steeringAngle;

    public static CarController cc;

    public float carMaxSpeed = 100;
    public float carCurrentSpeed = 0;

    public FixedJoystick joystick;

    Rigidbody rb;

    public void Start()
    {
        cc = this;
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float motor;
        float steering;


        if (Application.platform == RuntimePlatform.Android)
        {
            motor = Torque * joystick.Vertical;
            steering = steeringAngle * joystick.Horizontal;
        }
        else
        {
            motor = Torque * Input.GetAxis("Vertical");
            steering = steeringAngle * Input.GetAxis("Horizontal");
        }
        

        foreach (AxleInfo axleInfo in axleInfos)      //Works on each data present in the list
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
                carCurrentSpeed = (rb.velocity.magnitude * 20f) / carMaxSpeed;
            }
        }
    }
}
[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}
