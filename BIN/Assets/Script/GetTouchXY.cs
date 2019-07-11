using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetTouchXY : MonoBehaviour
{
    public GameObject move;
    private Camera subCamera;
    public void Start() {
        subCamera = GameObject.FindWithTag("SubCamera").GetComponent<Camera>();
    }
    public void getTouch(GameObject move) {
        this.gameObject.SetActive(true);
        this.move = move;
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 XY;
            //XY = Input.mousePosition;
            XY = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            move.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text = "" + XY.x;
            move.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text = "" + XY.y;
            
            this.gameObject.SetActive(false);

        }
    }
    
}
