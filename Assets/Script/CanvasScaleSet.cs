using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasScaleSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        double ratio = 0f;//비율
        double myRatio = (9f / 16f);
        ratio = (double)Screen.width / (double)Screen.height;
        if(ratio>myRatio)
            this.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
        else
            this.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
