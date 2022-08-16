using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CnCExerciseManager : MonoBehaviour
{
    
    public int a;

    [Header("Lists")]
    [SerializeField] List <int>Number; 
    [SerializeField] List <GameObject> food;

    [Header("Sprites")]
    public GameObject Okay;
    public GameObject happy;
    public GameObject sad;

    [Header("Buyer Info")]
    public int num;
    private GameObject gameObjects;

    [Header("Display")]
    public GameObject textDisplay;
    public GameObject scoreDisplay;
    public GameObject buyerDisplay;

    [Header("For Image")]
    public GameObject doughnutBlack;
    public GameObject doughnutPink;
    public GameObject doughnutWhite;
    public GameObject Croissant;
    public GameObject cheesecakeStrawberry;
    public GameObject cheesecakeChocolate;
    public GameObject cheesecakeLime;
    public GameObject cheesecakeBlueberry;

    [Header("Screen")]
    public int timeRemaining = 60;
    public int score = 0;
    public bool takingAway = false;
    public bool isNextLevel = true;
    public bool gameload = false;

    IEnumerator timerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        timeRemaining -= 1;
        textDisplay.GetComponent<Text>().text = "Time : " + timeRemaining;
        scoreDisplay.GetComponent<Text>().text = "Score : " + score;
        takingAway = false;
    }
   
    // Start is called before the first frame update
    void Awake()
    {

        Okay.SetActive(true);
        num = Number[Random.Range(0, Number.Count)];
        Debug.Log(num);
        gameObjects = food[Random.Range(0, food.Count)];
        Debug.Log (gameObjects);

        if (isNextLevel)
        {
            score = PlayerPrefs.GetInt("score");
            timeRemaining = PlayerPrefs.GetInt("timeRemaining");
        }
    }

    void Start()
    {
        if(gameObjects.name == "doughnutBlack")
        {
            doughnutBlack.SetActive(true);
        }
        
        else if (gameObjects.name == "doughnutPink")
        {
            doughnutPink.SetActive(true);
        }

        else if (gameObjects.name == "doughnutWhite")
        {
            doughnutWhite.SetActive(true);
        }

        else if (gameObjects.name == "Croissant")
        {
            Croissant.SetActive(true);
        }

        else if (gameObjects.name == "cheesecakeStrawberry")
        {
            cheesecakeStrawberry.SetActive(true);
        }

        else if (gameObjects.name == "cheesecakeChocolate")
        {
            cheesecakeChocolate.SetActive(true);
        }

        else if (gameObjects.name == "cheesecakeLime")
        {
            cheesecakeLime.SetActive(true);
        }

        else if (gameObjects.name == "cheesecakeBlueberry")
        {
            cheesecakeBlueberry.SetActive(true);
        }


        textDisplay.GetComponent<Text>().text = "Time : " + timeRemaining;
        scoreDisplay.GetComponent<Text>().text = "Score : " + score;
        buyerDisplay.GetComponent<Text>().text = "I Want : " + num;
        
    }
    void Update()
    {
      if(takingAway == false && timeRemaining > 0)
        {
            StartCoroutine(timerTake());
        }
        buyerDisplay.GetComponent<Text>().text = "I Want : " + num;
        
    }
    // Update is called once per frame
    public void onClick()
    {
        if (a == num && gameObjects.name == CnCobjectDrag.gameObj.name)
        {
            Debug.Log("Done");
            score += 10;
            timeRemaining += 60;
            Okay.SetActive(false);
            happy.SetActive(true);
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("timeRemaining", timeRemaining);
            isNextLevel = true;
            gameload = true;
            StartCoroutine(refreshscene());
        }
        else if(timeRemaining == 0)
        {
            Okay.SetActive(false);
            sad.SetActive(true);
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetInt("timeRemaining", 60);
            isNextLevel = false;
            gameload = true;
            StartCoroutine(refreshscene());
        }
        else
        {
            Okay.SetActive (false);
            sad.SetActive(true);
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetInt("timeRemaining", 60);
            isNextLevel = false;
            gameload = true;
            StartCoroutine(refreshscene());  
        }
    }
    IEnumerator refreshscene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnApplicationQuit()
    {
        resetgameComponents();
    }

    private void resetgameComponents()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("timeRemaining", 60);
    }
}
