using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonScript : MonoBehaviour
{
    public ManagerSandPaper manager;
    public AudioSoundsSandPaper audioSounds;
    bool isClicked;         // is tile has been clicked or not
    
    private void Start()
    {
        isClicked = false;
        
        manager = FindObjectOfType<ManagerSandPaper>();
        audioSounds = FindObjectOfType<AudioSoundsSandPaper>();
    }
    private void FixedUpdate()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


       if(!EventSystem.current.IsPointerOverGameObject() && manager.canClickOnButton )
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse Button Pressed");
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.GetComponent<TagOnObjects>() != null && hit.collider.gameObject.GetComponent<TagOnObjects>().tagOfObject == manager.currentTag && hit.collider.gameObject.name == this.gameObject.name)
                    {
                        manager.tileObjectsClicked.Add(hit.collider.gameObject);
                        Debug.Log(hit.collider.gameObject.name);
                        OnButtonClick();
                    }
                    else
                    {
                        Debug.Log("This is called");
                       // audioSounds.PlayAudioOnce(4);
                    }

                }
            }
        }
    }
    public void OnButtonClick()
    {

        if (!isClicked)
        {
            audioSounds.PlayAudioOnce(0);
            Debug.Log("Calling transform changing function");
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            isClicked = true;
            manager.tileCount++;
            if (manager.tileCount == 9)
            {
                manager.tracingButton.SetActive(true);
                //manager.BigTileSpawn(manager.tagIndex);
                manager.canClickOnButton = false;
            }
        }
    }



}
