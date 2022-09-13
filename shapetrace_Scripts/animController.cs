using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animController : MonoBehaviour
{
    Animator anim;
    public bool zoomed;
    public GameObject coll;

    public int a;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("click");
                zoomed = true;
                a++;
                StartCoroutine(collactive());
            }
        }
    }
    IEnumerator collactive()
    {
        yield return new WaitForSeconds(0.40f);
        coll.SetActive(true);
    }

}
