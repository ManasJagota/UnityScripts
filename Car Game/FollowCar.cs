using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public Transform Car;

    // Update is called once per frame
    void Update()
    {
        transform.position = Car.transform.position + new Vector3(1, 2, -10);
    }
}
