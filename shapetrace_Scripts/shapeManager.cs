using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapeManager : MonoBehaviour
{
    public static shapeManager instance;
    public int g;
    // Start is called before the first frame update
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
