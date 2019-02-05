using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class EnemyEdit:MonoBehaviour {
    public GameObject EnemyOption;
    private int flag = 0;
    private Vector2 MousePosition;
    int dragging;
    private MyUIHoverListener uiListener;

    // Start is called before the first frame update
    void Start() {
        uiListener = GameObject.Find("Canvas").GetComponent<MyUIHoverListener>();
        EnemyOption = GameObject.Find("sendGameObject").GetComponent<SendGameObject>().getEnemyOption();

    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.z!=0)
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f);
        /*if (Input.GetMouseButtonDown(0)) {
            flag = 1;
            MousePosition = Input.mousePosition;

        }
        if (Input.GetMouseButtonUp(0)) {
            flag = 0;
        }
        if (flag == 1 && (Vector2)Input.mousePosition != MousePosition) {
            this.gameObject.transform.position=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0f));
        }*/
    }
    void OnMouseUp() {
        //if (flag == 0)

        if (GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable) {
            if (dragging < 10)
                EnemyOption.gameObject.GetComponent<UIclose>().openEnemyOption(this.gameObject);
            else
                this.gameObject.GetComponent<EnemyData>().SpawnPoint = Camera.main.WorldToScreenPoint((Vector2)this.gameObject.transform.position);
            dragging = 0;
        }
        //else flag = 0;
    }
    void OnMouseDown() {
        if (GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable) {
            dragging = 0;
            flag = 1;
            MousePosition = Input.mousePosition;
            Debug.Log("클릭!");
        }
    }
    void OnMouseDrag() {
        if (GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable) {
            dragging++;
            if (dragging >= 10)
                this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        }
        
    }

}
