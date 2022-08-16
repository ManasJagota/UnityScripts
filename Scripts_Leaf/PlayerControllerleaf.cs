using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerleaf : MonoBehaviour
{
    public ScoreLeaf score;

    //public FixedTouchField FixedTouch;
    Drag_3Elements drag;
    [SerializeField] private puzzlecontrollerLeaf PuzzleController;

    //[SerializeField] puzzlecontroller PuzzleController;

    [SerializeField] private Rigidbody rb;
    //[SerializeField] private FixedJoystick joystick;
    [SerializeField] private float moveSpeed = 2f;

   // [SerializeField] private GameObject LookAtPos;
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;
    //[SerializeField] private float cameraSpeed = 100f;

   // [SerializeField] private GameObject JoystickCanves;
    [SerializeField] private GameObject canves;
    //public bool IsTriggered = false;

    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject MissionComplete;
    [SerializeField] GameObject InFOPanel;
    [SerializeField] GameObject JumpButton;

    [SerializeField] private AudioSource ScoreAudio;
    [SerializeField] private AudioSource JumpAudio;
    [SerializeField] private AudioSource GameOverAudio;
    [SerializeField] private AudioSource MissionCompleteAudio;
    [SerializeField] private AudioSource GameAudio;

    [SerializeField] private GameObject coins;

    private bool canjump;
    private bool isjumping;
    private float countDown;

    private void Start()
    {
        drag = GetComponent<Drag_3Elements>();
        GameAudio.Play();
       // Debug.Log("sound");

        canves.SetActive(false);
    }
   
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TriggeredObject")
        {
          // Debug.Log("is triggered");
            
            RandomChoose();
            cameraTwo();
            other.GetComponent<BoxCollider>().enabled = false; 
            //IsTriggered = true;
        }
        if(other.gameObject.name == "coins")
        {
            Destroy(other.gameObject);
            score.AddScore(0001);
            ScoreAudio.Play();
           // Debug.Log("Score added");
        }
        if (other.gameObject.name == "Water01")
        {
            GameOverAudio.Play();
            GameOverPanel.SetActive(true);
        }
        if (other.gameObject.name == "ForestCabin")
        {
            MissionCompleteAudio.Play();
            MissionComplete.SetActive(true);
        }
    }
    public void PuzzleGame()
    {
        PuzzleController.Cabinetsspawn();
        PuzzleController.LeafSpawn();
    }
    public void TracingGame()
    {
        PuzzleController.TracingSpawn();
    }
    void CameraOne()
    {
       // JoystickCanves.SetActive(true);
        camera1.SetActive(true);
        camera2.SetActive(false);
        canves.SetActive(false);
        JumpButton.SetActive(true);
    }
    void cameraTwo()
    {
     //   Time.timeScale = 10f;
        canves.SetActive(true);
       // JoystickCanves.SetActive(false);
        camera1.SetActive(false);
        camera2.SetActive(true);
        GameOverPanel.SetActive(false);
        MissionComplete.SetActive(false);
        JumpButton.SetActive(false);
    }
    public void completeBTN()
    {
      //  CameraOne();
        Debug.Log("finish");


        for(int  i =0;i<PuzzleController.LeafsObjClone.Count;i++)
        {
            if (!PuzzleController.LeafsObjClone[i].GetComponent<Drag_3Elements>().canDropLeafs)
            {
                Debug.Log("False Anser");
                return;
            }
            if(i == PuzzleController.LeafsObjClone.Count-1)
            {
                Debug.Log("cORRECT");
                foreach(var item in PuzzleController.LeafsObjClone)
                {
                    Destroy(item);

                }
                PuzzleController.LeafsObjClone.Clear();

                foreach (var item in PuzzleController.CabinetsObjClone)
                {
                    Destroy(item);

                }

                PuzzleController.CabinetsObjClone.Clear();
                CameraOne();
            }
        }
       

    }
    public void OnClickInfo()
    {
        InFOPanel.SetActive(true);
    }
    public void OnClickBack()
    {
        InFOPanel.SetActive(false);
    }
    public void RandomChoose()
    {
       float randomNumber = Random.Range(0f, 1f);

        //if(0f)
        //{
        //    PuzzleGame();
        //}
        //else
        //{
        //    TracingGame();
        //}
        switch (0)
        {
            case 0:
                PuzzleGame();
                break;
            case 1:
                TracingGame();
                break;
        }

        
    }
}
