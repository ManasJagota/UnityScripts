using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contoller : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene("Level1");
    }
}
