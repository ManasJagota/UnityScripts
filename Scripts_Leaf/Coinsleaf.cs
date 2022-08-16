using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinsleaf : MonoBehaviour
{
    public float turnningSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "Character.001")
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnningSpeed * Time.deltaTime);
    }
}
