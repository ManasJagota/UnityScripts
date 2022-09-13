using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingNumberCard_drag : MonoBehaviour
{
    Vector3 offset;

    [SerializeField] Vector3 intialtransform;
    public Vector3 correctPosition;
    public bool isMouseUp;

    public bool rightpos;
    public bool isReplaced;

    public AudioSource audio;

    void Start()
    {
        intialtransform = transform.position;
        rightpos = false;
    }


    private void Update()
    {
        if (isMouseUp && !isReplaced)
        {
            if (rightpos && correctPosition != null)
            {
                Debug.Log("Change pos");
                transform.position = correctPosition;
             
                GetComponent<BoxCollider>().enabled = false;


                isReplaced = true;
                CountingNumberCard_Manager.instance.score += 1;

                audio.Play();

                if (transform.position != correctPosition)
                {
                    transform.position = correctPosition;
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
        isMouseUp = false;
    }

    void OnMouseDrag()
    {
        transform.position = new Vector3(GetMousePosition().x, transform.position.y, GetMousePosition().z);
    }



    private void OnMouseUp()
    {
        isMouseUp = true;
    }


    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.name == this.gameObject.name)
        {

            Debug.Log("Hit");

            rightpos = true;
            correctPosition = collision.transform.position;

        }


    }

    private void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.name == this.gameObject.name)
        {

            Debug.Log("Hit");

            rightpos = true;
            correctPosition = collision.transform.position;

        }


    }


    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("exit");
        rightpos = false;
    }

    Vector3 GetMousePosition()
    {
        var screenPos = Input.mousePosition;
        
        screenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(screenPos);
    }
}
