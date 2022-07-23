using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;         //To get information about the basic axle which store information about control
    public float Torque;                     // To give torque or provide force for movement
    public float steeringAngle;              // To give angle for rotation

    public void FixedUpdate()
    {
        float motor = Torque * Input.GetAxis("Vertical");          
        float steering = steeringAngle * Input.GetAxis("Horizontal");

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

