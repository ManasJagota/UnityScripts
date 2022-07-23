using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoin : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        CollectCount.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}
