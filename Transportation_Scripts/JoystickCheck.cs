using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCheck : MonoBehaviour
{
    public GameObject joystick;
    // Start is called before the first frame update
    public void checkJoystick()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            joystick.SetActive(true);
        }
    }
}
