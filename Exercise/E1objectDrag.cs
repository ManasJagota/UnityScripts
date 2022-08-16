using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class E1objectDrag : MonoBehaviour
{

    Vector3 offset;

    [SerializeField] Vector3 intialtransform;
    public Vector3 correctPosition;
    public bool isMouseUp;


    [SerializeField] GameObject parentObject;


    public bool rightpos;
    public bool isReplaced;

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
                
                GetComponent<CircleCollider2D>().enabled = false;


                isReplaced = true;
                E1ExcerciseManager.instance.score += 1;
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
        offset = transform.position - GetMousePosition();
        isMouseUp = false;
    }

    void OnMouseDrag()
    {

        transform.position = GetMousePosition() + offset;
    }



    private void OnMouseUp()
    {
        isMouseUp = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == this.gameObject.name)
        {

            Debug.Log("Hit");

            rightpos = true;
            correctPosition = collision.transform.position;

        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name == this.gameObject.name)
        {

            Debug.Log("Hit");

            rightpos = true;
            correctPosition = collision.transform.position;

        }


    }


    private void OnTriggerExit2D(Collider2D collision)
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

