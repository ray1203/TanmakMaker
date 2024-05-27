using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick:MonoBehaviour {

    // 공개
    public Transform Stick;         // 조이스틱.
    public Transform Player;
    // 비공개
    private Vector3 JoystickNormalPos;
    private Vector3 StickFirstPos;  // 조이스틱의 처음 위치.
    private Vector3 JoyVec;         // 조이스틱의 벡터(방향)
    private float Radius;           // 조이스틱 배경의 반 지름.
    private int JoyId=0;

    void Start() {
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        // 캔버스 크기에대한 반지름 조절.
            StickFirstPos = Stick.transform.position;
            StickFirstPos.z = 0f;
        JoystickNormalPos = StickFirstPos;
        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;
    }
    public bool touchFlag = false;
    void Update() {
        if (Input.touchCount > 0) {
        Touch touch = Input.GetTouch(0);
        
            for(int i = 0; i < Input.touchCount; i++) {
                if (JoyId == Input.GetTouch(i).fingerId) {
                    touch = Input.GetTouch(i);
                    break;
                }
        }

        float inputx, inputy;
        if (Player) {
        inputx = JoyVec.x * Time.deltaTime * Player.GetComponent<PlayerCtrl>().playerSpeed;
        inputy = JoyVec.y * Time.deltaTime * Player.GetComponent<PlayerCtrl>().playerSpeed;

        Player.gameObject.transform.Translate(inputx, inputy, 0);

        }
        //if (Input.touchCount>0) {
        if (touch.phase == TouchPhase.Began) {
                Debug.Log("beg");
            //StickFirstPos = Input.GetTouch(0).position;
            StickFirstPos = Camera.main.ScreenToWorldPoint(touch.position);
            StickFirstPos.z = 0f;
            this.transform.parent.position = StickFirstPos;
            this.transform.localPosition = new Vector3(0f, 0f, 0f);
            Stick.localPosition = new Vector3(0f, 0f, 0f);
            JoyVec = Vector3.zero;
        }
        if (touch.phase==TouchPhase.Moved&&JoyId==touch.fingerId) {
                if (!touchFlag) {
                    touchFlag = true;
                    Debug.Log("beg");

                }
                
                Debug.Log("moved");
                Vector3 Pos = (touch.position) - new Vector2(Camera.main.WorldToScreenPoint(this.transform.parent.position).x, Camera.main.WorldToScreenPoint(this.transform.parent.position).y);
                //Vector3 Pos = Camera.main.ScreenToWorldPoint(touch.position); 
                    Pos.z = 0f;
            Pos += StickFirstPos;
            // 조이스틱을 이동시킬 방향을 구함.(오른쪽,왼쪽,위,아래)
            JoyVec = (Pos - StickFirstPos).normalized;
                Debug.Log(Pos + "," + StickFirstPos + "," + JoyVec+","+touch.position+","+ Camera.main.ScreenToWorldPoint(touch.position)+","+ new Vector2(Camera.main.WorldToScreenPoint(this.transform.position).x, Camera.main.WorldToScreenPoint(this.transform.position).y));
            if(Pos.x-StickFirstPos.x<10&& Pos.x - StickFirstPos.x > -10&& Pos.y - StickFirstPos.y < 10 && Pos.y - StickFirstPos.y > -10) {
                Debug.Log("zero");
                JoyVec = new Vector3(0f, 0f, 0f);
                    Pos = StickFirstPos;
            }
            
            // 조이스틱의 처음 위치와 현재 내가 터치하고있는 위치의 거리를 구한다.
            
            float Dis = Vector3.Distance(Pos, StickFirstPos);
            if (Dis < 1) Dis = 0;
            
            if (StickFirstPos!= Camera.main.ScreenToWorldPoint(touch.position)) {
                    //Debug.Log(Radius+","+StickFirstPos+Pos+JoyVec+Dis);
                    // 거리가 반지름보다 작으면 조이스틱을 현재 터치하고 있는곳으로 이동. 
                    if (Dis <= Radius) {
                        Debug.Log("1");
                        // Stick.localPosition = StickFirstPos + JoyVec * Dis;
                        Stick.localPosition = JoyVec * Dis;
                        Debug.Log("AA" + Stick.localPosition + "," + StickFirstPos);
                        // 거리가 반지름보다 커지면 조이스틱을 반지름의 크기만큼만 이동.
                    } else {
                        Debug.Log("2");
                        Stick.localPosition =JoyVec * Radius;
                    }
            }
            
        }
        if (touch.phase == TouchPhase.Ended) {
                StickFirstPos = new Vector3(0, 0, 0);
                touchFlag = false;
                Debug.Log("end");
                this.transform.localPosition= new Vector3(0f, 0f, 0f);
            Stick.localPosition = new Vector3(0f, 0f, 0f);
            JoyVec = Vector3.zero;

        }
        }
        
    }/*
    // 드래그
    public void Drag(BaseEventData _Data) {
        Debug.Log("DDDA");
        PointerEventData Data = _Data as PointerEventData;
        //Vector3 Pos = Camera.main.ScreenToWorldPoint(Data.position);
        Vector3 Pos = Data.position-new Vector2(Camera.main.WorldToScreenPoint(this.transform.position).x, Camera.main.WorldToScreenPoint(this.transform.position).y);
        Pos.z = 0f;
        // 조이스틱을 이동시킬 방향을 구함.(오른쪽,왼쪽,위,아래)
        JoyVec = (Pos - StickFirstPos).normalized;

        // 조이스틱의 처음 위치와 현재 내가 터치하고있는 위치의 거리를 구한다.
        float Dis = Vector3.Distance(Pos, StickFirstPos);
        //Debug.Log(Radius+","+StickFirstPos+Pos+JoyVec+Dis);
        // 거리가 반지름보다 작으면 조이스틱을 현재 터치하고 있는곳으로 이동. 
        if (Dis <= Radius)
            Stick.localPosition = StickFirstPos + JoyVec * Dis;
        // 거리가 반지름보다 커지면 조이스틱을 반지름의 크기만큼만 이동.
        else
            Stick.localPosition = StickFirstPos + JoyVec * Radius;

    }

    // 드래그 끝.
    public void DragEnd() {
        //Stick.position = StickFirstPos; // 스틱을 원래의 위치로.
        Stick.localPosition = new Vector3(0f, 0f, 0f);
        JoyVec = Vector3.zero;          // 방향을 0으로.
    }*/
}

