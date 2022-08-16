using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Vector3 offset;
  
 //   public Quaternion initialRotation;
   [SerializeField] private GameObject player;
    // Start is called before the first frame update
    public bool isActive;

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            transform.position = player.transform.position + offset;
            //if (GameObject.Find("Player") != null)
            //{
            //    player = GameObject.Find("Player");
               
            //}

        }
    }
    public void offCal()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player");
            offset = transform.position - player.transform.position;
            isActive = true;
        }
        else if (GameObject.Find("Player4") != null)
        {
            player = GameObject.Find("Player4");
            offset = transform.position - player.transform.position;
            isActive = true;
        }
    }
    public void confirm()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player");
            transform.position = player.transform.position + offset;
            isActive = true;
        }
        else if (GameObject.Find("Player4") != null)
        {
            player = GameObject.Find("Player4");
            transform.position = player.transform.position + offset + new Vector3(0f , 0.8f , - 0.8f);
            isActive = true;
        }
       
    }
}
