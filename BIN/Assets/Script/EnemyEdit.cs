using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class EnemyEdit:MonoBehaviour {
    public GameObject EnemyOption;
    private Camera subCamera;
    int dragging;
    
    void Start() {
        try {
        EnemyOption = GameObject.Find("sendGameObject").GetComponent<SendGameObject>().getEnemyOption();
        subCamera = GameObject.FindWithTag("SubCamera").GetComponent<Camera>();

        } catch {

        }
    }
    
    void Update()
    {
        if (EnemyOption == null) {
            if (!GameObject.Find("sendGameObject")) {
                EnemyOption = new GameObject();
            } else {
                EnemyOption = GameObject.Find("sendGameObject").GetComponent<SendGameObject>().getEnemyOption();
            }

        }
        if (this.gameObject.transform.position.z!=0)
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f);
    }
    void OnMouseUp() {

        if (GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable) {
            if (dragging < 10)
                EnemyOption.gameObject.GetComponent<UIclose>().openEnemyOption(this.gameObject);
            else
                this.gameObject.GetComponent<EnemyData>().Pos[0] = this.gameObject.transform.position;
            dragging = 0;
        }
    }
    void OnMouseDown() {
        if (GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable) {
            dragging = 0;
        }
    }
    void OnMouseDrag() {
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition) +"+"+ Camera.main.ScreenToWorldPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))+"+"+ (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))+"+"+Camera.main.WorldToScreenPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f)));
        if (GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable) {
            dragging++;
            if (dragging >= 10) {
                this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                this.gameObject.GetComponent<EnemyData>().Pos[0] = this.gameObject.transform.position;
            }
        }
        
    }
    public void edit() {
        EnemyOption.gameObject.GetComponent<UIclose>().openEnemyOption(this.gameObject);
    }
}
