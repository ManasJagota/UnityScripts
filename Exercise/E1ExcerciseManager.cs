using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E1ExcerciseManager : MonoBehaviour
{
    public static E1ExcerciseManager instance;
    public int scoreNeeded;
    public int score;

    public GameObject panel;
    public GameObject environment;
    public GameObject circle;
    public GameObject number;
    public GameObject button;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {
        if (score == scoreNeeded)
        {
            StartCoroutine(NextLevel());

        }
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        score = 0;
        panel.SetActive(true);
        environment.SetActive(false);
        number.SetActive(false);
        circle.SetActive(false);
        button.SetActive(false);
    }
}
