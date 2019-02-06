using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetTouchXY : MonoBehaviour
{
    public GameObject summon, firstmove, secondmove;
    int flag;
    public void getTouch(int flag) {
        this.gameObject.SetActive(true);
        this.flag = flag;
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 XY;
            XY = Input.mousePosition;
            switch (flag) {
                case 0:
                    summon.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text = "" + XY.x;
                    summon.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text = "" + XY.y;
                    break;
                case 1:
                    firstmove.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text = "" + XY.x;
                    firstmove.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text = "" + XY.y;
                    break;
                case 2:
                    secondmove.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text = "" + XY.x;
                    secondmove.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text = "" + XY.y;
                    break;
            }
            this.gameObject.SetActive(false);

        }
    }
    
}
