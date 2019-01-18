using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyEdit:MonoBehaviour {
    public GameObject EnemyOption;
    void Awake() {
    }
    // Start is called before the first frame update
    void Start() {
        EnemyOption = GameObject.Find("sendGameObject").GetComponent<SendGameObject>().getEnemyOption();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown() {
        EnemyOption.gameObject.GetComponent<UIclose>().openEnemyOption(this.gameObject);   
    }

}
