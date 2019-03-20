using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EditorStarter : MonoBehaviour {
    public Slider slider;
    public GameObject OptionBar;
    void Start() {
        if (GameObject.FindWithTag("fill")) {
            GameObject e_empty = GameObject.FindWithTag("empty");
            GameObject e_fill = GameObject.FindWithTag("fill");
            int childCount = e_fill.transform.childCount;
            for (int i = 0; i < childCount; i++) {
                slider.GetComponent<TimeSelect>().MaxSummonTime(e_fill.transform.GetChild(0).GetComponent<EnemyData>().SpawnTime);
                e_fill.transform.GetChild(0).transform.position = (e_fill.transform.GetChild(0).GetComponent<EnemyData>().SpawnPoint);
                Debug.Log(e_fill.transform.GetChild(0).GetComponent<EnemyData>().SpawnPoint);
                e_fill.transform.GetChild(0).SetParent(e_empty.transform);
            }
            Destroy(e_fill);
        }
        
    }
}
