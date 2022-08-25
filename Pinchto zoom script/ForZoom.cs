using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForZoom : MonoBehaviour
{
    public float initialDis;
    public Vector3 initialScale;
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 2)
        {
            var touchZero = Input.GetTouch(0);
            var touchOne = Input.GetTouch(1);

            if(touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled || touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
            {
                return;
            }
            if(touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                initialDis = Vector2.Distance(touchZero.position, touchOne.position);
                initialScale = gameObject.transform.localScale;

            }
            else
            {
                var currentDis = Vector2.Distance(touchZero.position, touchOne.position);
                if(Mathf.Approximately(initialDis,0))
                {
                    return;
                }
                var factor = currentDis/ initialDis;
                gameObject.transform.localScale = initialScale * factor;
            }

        }
    }
}
