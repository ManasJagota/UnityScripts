using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLeaf : MonoBehaviour
{
    public Text ScoreText;
    int myScore = 0000;
   
    void Start()
    {
        ScoreText = this.GetComponent<Text>();
    }
    public void AddScore(int score)
    {
        myScore = myScore + 0001;
    }
   
    void Update()
    {
        ScoreText.text = myScore.ToString();
    }
}
