using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CnCobjectDrag : MonoBehaviour
{
    // The difference between where the mouse is on the drag plane and 
    // where the origin of the object is on the drag plane
    Vector3 offset;
    private static Vector3 offset1;
    private static Vector3 offset2;

    [SerializeField] Vector3 intialtransform;
    public Vector3 correctPosition;
    public bool isMouseUp;
    public bool isreplaced;
    [SerializeField]public bool isTriggering;
 

    [SerializeField] public GameObject parentObject;
    public static GameObject gameObj;

    public bool rightpos;
    public CnCExerciseManager manager;

    void Start()
    {
        intialtransform = transform.position;
        rightpos = false;
        gameObj = this.gameObject;
        if(manager.gameload == true)
        {
            offset1 = new Vector3(0f, 0f, 0f);
            offset2 = new Vector3(0f, 0f, 0f);
            manager.gameload = false;
        }
    }


    private void Update()
    {
        
        
        if (isMouseUp && !isreplaced)
        {
            if (rightpos && correctPosition != null)
            {
                if (manager.a == 0)
                {
                    transform.position = correctPosition + new Vector3(0.067f, -0.145f, 0.2f);
                   
                    offset1 = transform.position;
                    manager.a++;
                    respawn();
                    
                    Debug.Log(manager.a);
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                }

                else if(manager.a == 1)
                {
                    
                    transform.position = correctPosition + new Vector3(-0.3f, -0.145f, 0.2f);
                    //gameObject.GetComponent<BoxCollider>().enabled = false; 
                    offset2 = transform.position;
                    manager.a++;
                    respawn();
           
                    Debug.Log(manager.a);
                    gameObject.GetComponent<BoxCollider>().enabled = false;

                }
                else if(manager.a == 2 || manager.a == 4 || manager.a == 6 || manager.a == 8)
                {
                  
                    transform.position = offset1 + new Vector3(0f, 0f, -0.2f);
                    offset1 = transform.position;
                   
                    manager.a++;
                    respawn();
              
                    Debug.Log(manager.a);
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                else if (manager.a == 3 || manager.a == 5 || manager.a == 7 || manager.a == 9)
                {
                   
                    transform.position = offset2 + new Vector3(0f, 0f, -0.2f);
                    offset2 = transform.position;
                   
                    manager.a++;
                    respawn();
                    Debug.Log(manager.a);
               
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                }

            }
            else
            {
                transform.position = intialtransform;
            }
        }

    }

    void OnMouseDown()
    {
        offset = transform.position - GetMousePosition();
        isMouseUp = false;
        //dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
        //Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        //float planeDist;
        //dragPlane.Raycast(camRay, out planeDist);
        //offset = transform.position - camRay.GetPoint(planeDist);
    }

    void OnMouseDrag()
    {
        transform.position = GetMousePosition() + offset;
        //Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        //float planeDist;
        //dragPlane.Raycast(camRay, out planeDist);
        //transform.position = camRay.GetPoint(planeDist) + offset;
    }



    private void OnMouseUp()
    {
        isMouseUp = true;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "CakeTray")
        {
            isTriggering = true;
            Debug.Log("Hit");
            rightpos = true;
            correctPosition = collision.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "CakeTray")
        {
            isTriggering = true;
            Debug.Log("Hit");
            rightpos = true;
            correctPosition = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        rightpos = false;
        isTriggering = false;

    }

    public void respawn()
    {
        Debug.Log("Replace");
        GameObject clone = Instantiate(gameObject);
        clone.transform.position = intialtransform;
        clone.transform.SetParent(parentObject.transform);
        clone.name = gameObject.name;
        isreplaced = true;
    }



    Vector3 GetMousePosition()
    {
        var screenPos = Input.mousePosition;
        screenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(screenPos);
        
    }
   
}

