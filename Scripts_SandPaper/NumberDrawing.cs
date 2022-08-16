using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDrawing : MonoBehaviour
{
    [SerializeField] List<Transform> coins = new List<Transform>();     // list of all the coins present in big tile no. prefab
    [SerializeField] Animator coinAnimator;         
    [SerializeField] ManagerSandPaper manager;
    [SerializeField] string firstCoin;
    [SerializeField] string lastCoin;
    [SerializeField] string coin;                                       // stroing the next coin name that player have to click
    [SerializeField] int coinIndex;                                     // coin index from list on which it is iterating currently
    

    [SerializeField] bool isEnded;
    [SerializeField] bool mouseButtonPressed;
    [SerializeField] AudioSoundsSandPaper audioSounds;
  

    private void Awake()
    {
        GetComponentsInChildren<Transform>(false, coins);
        coins.RemoveAt(0);
    }

    private void Start()
    {
        audioSounds = FindObjectOfType<AudioSoundsSandPaper>();
        manager = FindObjectOfType<ManagerSandPaper>();
        IntializingComponent();
    }

   

    void IntializingComponent()
    {
        manager = FindObjectOfType<ManagerSandPaper>();
        firstCoin = coins[0].name;
        lastCoin = coins[coins.Count - 1].name;
        coinIndex = 0;
        coin = coins[coinIndex].name;
    }

    private void FixedUpdate()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButton(0) && !isEnded)
        {
            mouseButtonPressed = true;
            if(Physics.Raycast(ray, out hit))
            {
                if (/*hit.collider.gameObject.GetComponent<ObjectTag>().tagOfObject ==manager.currentTag &&*/ hit.collider.gameObject.name == coin)
                {
                    audioSounds.PlayAudioOnce(1);
                    hit.collider.gameObject.SetActive(false);
                    if(coinIndex < coins.Count-1)
                    {
                        coinIndex++;
                        Debug.Log("coins index" + coinIndex);
                        Debug.Log(coins.Count);
                       
                    }
                    if(coin == lastCoin)
                    {
                      
                        isEnded = true;
                        Debug.Log("IseNDED TRUE");
                        manager.wellPlayedText.SetActive(true);
                        audioSounds.PlayAudioOnce(3);
                         StartCoroutine(DeactivatingGameObject());

                      
                        
                    }
                    coin = coins[coinIndex].name;
                }
               
            }
        }
        else
        {
            mouseButtonPressed = false;
        }

        if(!mouseButtonPressed && !isEnded )
        {
            Debug.Log("This called");
            foreach(var c in coins)
            {
                c.gameObject.SetActive(true);
                IntializingComponent();
            }
        }
    }


    IEnumerator DeactivatingGameObject()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
        manager.wellPlayedText.SetActive(false);
        manager.canClickOnButton = true;
        manager.tileObjectsClicked.Clear();

        if (manager.tagIndex < 8)
        {
            Debug.Log("here 1");
            manager.tagIndex += 1;
            manager.currentTag = manager.tagList[manager.tagIndex];
        }
        else
        {
            manager.replayUIPanel.SetActive(true);
        }
    }
}
