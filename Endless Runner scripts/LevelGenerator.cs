using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 50;
    public bool creatingSection = false;
    public int secNum;

    // Update is called once per frame
    void Update()
    {
     if(creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(generateSection());
        }
    }
    IEnumerator generateSection()
    {
        secNum = Random.Range(0, 1);
        Instantiate(section[secNum], new Vector3(0,0,zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }
}
