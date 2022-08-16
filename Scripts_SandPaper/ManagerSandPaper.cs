using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerSandPaper : MonoBehaviour
{

    [SerializeField] GameObject[] bigTilePrefab;        // array of big tile prefab that to e=be sapwned after click on each tile a particular no.
    [SerializeField] GameObject[] discoPlatformPrefab;  // array of diiferent kind of platorm to be spawn when starting game
    [SerializeField] GameObject[] gameInstructions;     // array of different gameobjects of instruction for different platforms
    [SerializeField] AudioSource audioSource;           // audio source for continue background loop
    [SerializeField] GameObject startingTextObject;     // text display object when game is starting
    [SerializeField] AudioSoundsSandPaper audioSounds;
    
    


    public List<GameObject> tileObjectsClicked;       // to store 9 tile of a single color on which player has clicked
    public List<string> tagList;        //storing the string list of name of tags of tile
    public string currentTag;           // tag of the object on which we can click
    public GameObject wellPlayedText;         // text after tracing object


    public int tileCount;       // for storing no. of tile that has been clicked
    public int tagIndex;    // for increasing index of checking tag
    public bool canClickOnButton;       // boolean to check if player can click on tile or not
    public GameObject tracingButton;    // button object for spawning big tile
    public GameObject replayUIPanel;           // retry panel after the game has been completed


    private GameObject currentGameInstruction;      // storing the instruction gameobjects using in current platform

    bool isPlatformSpawned;


    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            currentGameInstruction = gameInstructions[0];
        }
        else
        {
            currentGameInstruction = gameInstructions[1];
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startingTextObject.SetActive(true);
        wellPlayedText.SetActive(false);
        currentGameInstruction.SetActive(false);
        replayUIPanel.SetActive(false);
        tracingButton.SetActive(false);
        canClickOnButton = true;
        tagIndex = 0;
        tileCount = 0;
        currentTag = tagList[tagIndex];
        isPlatformSpawned = false;
        audioSource.Play();
        StartCoroutine(StartDisplay());
    }
    private void Update()
    {
        if(!isPlatformSpawned)
        {
            SpawnDiscoPlatform();
        }

    }

    void SpawnDiscoPlatform()
    {
        int random = Random.Range(0, discoPlatformPrefab.Length);
        GameObject platform = Instantiate(discoPlatformPrefab[random]);
        isPlatformSpawned = true;
    }


    public void BigTileSpawn(int index)
    {
       
        foreach (GameObject g in tileObjectsClicked)
        {
            g.SetActive(false);
        }
       
        GameObject tile = Instantiate(bigTilePrefab[index]);
        tile.transform.position = new Vector3(-7f, 2f, 11f);
        tile.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        tileCount = 0;
        currentTag = "coins";
        //if (tagIndex < 9)
        //{
        //    tagIndex += 1;
        //}
        //currentTag = tagList[tagIndex];
    }




    #region OnClick Functions
    public void OnTracingButtonClick()
    {
        audioSounds.PlayAudioOnce(2);
        BigTileSpawn(tagIndex);
        tracingButton.SetActive(false);
    }


    public void OnInstructionButtonClick()
    {
        audioSounds.PlayAudioOnce(2);
        currentGameInstruction.SetActive(true);
    }

    public void OnCrossButtonClick()
    {
        audioSounds.PlayAudioOnce(2);
        currentGameInstruction.SetActive(false);
    }

    public void OnReplayButtonClick()
    {
        audioSounds.PlayAudioOnce(2);
        replayUIPanel.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


    #endregion


    IEnumerator StartDisplay()
    {
        yield return new WaitForSeconds(3f);
        startingTextObject.SetActive(false);
    }
}
