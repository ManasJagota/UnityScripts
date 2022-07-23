using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        CollectCount.coinCount = 0;
       Application.LoadLevel("SampleScene");
    }
}
