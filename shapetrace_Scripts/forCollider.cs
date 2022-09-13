using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forCollider : MonoBehaviour
{
    public bool isMouseUp;

    public GameObject[] joints;
    public GameObject[] Colliders;

    public GameObject coll;

    [SerializeField] Vector3 intialtransform;

    public bool traceComp;

    [SerializeField] Animator an;

    public int n;

    public bool isTriggered;

    public GameObject covercoll;

    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMouseUp && !traceComp)
        {
            foreach(GameObject join in joints)
            {
                join.SetActive(false);
                transform.position = intialtransform;
                n = 0;
            }
        }
    }


    void OnMouseDown()
    {
        intialtransform = transform.position;
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
        Debug.Log(collision.gameObject.name);
        isTriggered = true;
        if (collision.gameObject.name == Colliders[n].name)
        {

            joints[n].SetActive(true);
            if(n!=Colliders.Length)
               n++;
            if (n == Colliders.Length)
            {
                an.SetTrigger("move");
                
                traceComp = true;
                StartCoroutine(coverCollider());
                Destroy(rb);
            }
           
        }


    }

    Vector3 GetMousePosition()
    {
        var screenPos = Input.mousePosition;

        screenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(screenPos);
    }

    IEnumerator coverCollider()
    {
        yield return new WaitForSeconds(1f);
            covercoll.SetActive(true);
        
    }
}
