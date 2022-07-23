using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCount : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;
    void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = "Score: " + coinCount;
    }
}
