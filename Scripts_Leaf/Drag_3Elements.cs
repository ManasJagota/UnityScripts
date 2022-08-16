using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_3Elements : MonoBehaviour
{
    Vector3 MOffset;
    public Vector3 InitialPos;
    public bool isMouseDrag = false;

    [SerializeField] public  bool canDropLeafs;
    [SerializeField] GameObject CorrectCabinets;
    Vector3 rightpos;
    Vector3 currentPos;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private void Start()
    {
        InitialPos = transform.position;
    }
    private void Update()
    {
        if (isMouseDrag)
        {
            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit rayCastHit))
            {
             //   Debug.Log(rayCastHit.collider.gameObject.name);

                if (rayCastHit.collider.gameObject.name == this.gameObject.name )
                {
                   // Debug.Log("right place");
                    canDropLeafs = true;
                  //  Debug.Log(rayCastHit.point);
                    rightpos = rayCastHit.collider.gameObject.transform.position;
                    return;
                } 
            }
        }
    }
    public void OnMouseDown()
    {
        isMouseDrag = false;
        MOffset = transform.position - MouseWorldPos();
    }
    public void OnMouseDrag()
    {
        isMouseDrag = true;
        transform.position = MouseWorldPos() + MOffset;
        
    }
    private void OnMouseUp()
    {
        isMouseDrag = false;
        if (canDropLeafs)
        {
            this.transform.localPosition = rightpos;
        }
        else
        {
            transform.position = InitialPos;
        }
    }
    public Vector3 MouseWorldPos()
    {
       var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
