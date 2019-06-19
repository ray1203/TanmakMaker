using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowEnemyList:MonoBehaviour {
    public GameObject Enemy, time, Content, EnemyContent;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void show() {
        for (int i = 0; i < Content.transform.childCount; i++) {
            Destroy(Content.transform.GetChild(i).gameObject);
        }
        float t = time.GetComponent<Slider>().value;
        for (int i = 0; i < Enemy.transform.childCount; i++) {
            if ((int)Mathf.Floor(Enemy.transform.GetChild(i).GetComponent<EnemyData>().SpawnTime) == (int)t) {
                GameObject newObject = Instantiate(EnemyContent);
                newObject.transform.Find("Button").GetComponent<ShowEnemyListData>().editingEnemy = Enemy.transform.GetChild(i).gameObject;
                newObject.transform.SetParent(Content.transform);
                newObject.transform.localScale = new Vector3(1f, 1f, 0f);
                newObject.transform.position = new Vector3(newObject.transform.position.x, newObject.transform.position.y, 0f);
            }
        }
    }
    public void deleteNow() {
        float t = time.GetComponent<Slider>().value;
        for (int i = 0; i < Enemy.transform.childCount; i++) {
            if ((int)Mathf.Floor(Enemy.transform.GetChild(i).GetComponent<EnemyData>().SpawnTime) == (int)t) {
                Destroy(Enemy.transform.GetChild(i).gameObject);
            }
        }
    }
}
