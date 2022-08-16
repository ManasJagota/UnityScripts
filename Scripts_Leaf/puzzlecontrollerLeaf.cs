using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlecontrollerLeaf : MonoBehaviour
{
    public Transform[] CabinetsPos;
    [SerializeField] public GameObject[] cabinetsObj;
    [SerializeField] public List<GameObject> CabinetsObjClone;

    public Transform[] LeafsPos;
    [SerializeField] public GameObject[] LeafsObj;
    public List<GameObject> LeafsObjClone;

    [SerializeField] private GameObject TracingPos;
    public GameObject[] TracingsObj;
    
    public void Cabinetsspawn()
    {
        for(int  i =0; i <cabinetsObj.Length; i++)
        {
            GameObject cabinet = Instantiate(cabinetsObj[i], CabinetsPos[i].transform.position, Quaternion.Euler(0, 0, 0));
            CabinetsObjClone.Add(cabinet);
        }

        //cabinetsObjClone[0] = Instantiate(cabinetsObj[0], CabinetsPos[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //cabinetsObjClone[1] = Instantiate(cabinetsObj[1], CabinetsPos[1].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //cabinetsObjClone[2] = Instantiate(cabinetsObj[2], CabinetsPos[2].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //cabinetsObjClone[3] = Instantiate(cabinetsObj[3], CabinetsPos[3].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //cabinetsObjClone[4] = Instantiate(cabinetsObj[4], CabinetsPos[4].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //cabinetsObjClone[5] = Instantiate(cabinetsObj[5], CabinetsPos[5].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //cabinetsObjClone[6] = Instantiate(cabinetsObj[6], CabinetsPos[6].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //cabinetsObjClone[7] = Instantiate(cabinetsObj[7], CabinetsPos[7].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //cabinetsObjClone[8] = Instantiate(cabinetsObj[8], CabinetsPos[8].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //cabinetsObjClone[9] = Instantiate(cabinetsObj[9], CabinetsPos[9].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    public void LeafSpawn()
    {
        for (int i = 0; i < LeafsObj.Length; i++)
        {
            GameObject leaf = Instantiate(LeafsObj[i], LeafsPos[i].transform.position, Quaternion.Euler(0, 0, 0));
            LeafsObjClone.Add(leaf);
        }

        //LeafsObjClone[0] = Instantiate(LeafsObj[0], LeafsPos[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //LeafsObjClone[1] = Instantiate(LeafsObj[1], LeafsPos[1].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //LeafsObjClone[2] = Instantiate(LeafsObj[2], LeafsPos[2].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //LeafsObjClone[3] = Instantiate(LeafsObj[3], LeafsPos[3].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //LeafsObjClone[4] = Instantiate(LeafsObj[4], LeafsPos[4].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //LeafsObjClone[5] = Instantiate(LeafsObj[5], LeafsPos[5].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //LeafsObjClone[6] = Instantiate(LeafsObj[6], LeafsPos[6].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //LeafsObjClone[7] = Instantiate(LeafsObj[7], LeafsPos[7].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //LeafsObjClone[8] = Instantiate(LeafsObj[8], LeafsPos[8].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //LeafsObjClone[9] = Instantiate(LeafsObj[9], LeafsPos[9].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }
    public void TracingSpawn()
    {
       // Debug.Log("calling Tracing Spawn");
        int a = Random.Range(0, LeafsObj.Length);
        Instantiate(TracingsObj[a], TracingPos.transform.position, LeafsObj[a].transform.rotation);
    }
}
