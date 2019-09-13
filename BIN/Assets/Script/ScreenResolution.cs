using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenResolution : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1080, 1920, true);
    }


}
