using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class EnemyEdit:MonoBehaviour {
    public GameObject EnemyOption;
    int dragging;
    
    void Start() {
        EnemyOption = GameObject.Find("sendGameObject").GetComponent<SendGameObject>().getEnemyOption();

    }
    
    void Update()
    {
        if(EnemyOption==null) EnemyOption = GameObject.Find("sendGameObject").GetComponent<SendGameObject>().getEnemyOption();
        if (this.gameObject.transform.position.z!=0)
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f);
    }
    void OnMouseUp() {

        if (GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable) {
            if (dragging < 10)
                EnemyOption.gameObject.GetComponent<UIclose>().openEnemyOption(this.gameObject);
            else
                this.gameObject.GetComponent<EnemyData>().SpawnPoint = Camera.main.WorldToScreenPoint((Vector2)this.gameObject.transform.position);
            dragging = 0;
        }
    }
    void OnMouseDown() {
        if (GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable) {
            dragging = 0;
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
