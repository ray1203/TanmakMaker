using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EditorStarter : MonoBehaviour {
    public Slider slider;

    void Start() {
        if (GameObject.FindWithTag("fill")) {
            GameObject e_empty = GameObject.FindWithTag("empty");
            GameObject e_fill = GameObject.FindWithTag("fill");
            for(int i = 0; i < e_fill.transform.childCount; i++) {
                slider.GetComponent<TimeSelect>().MaxSummonTime(e_fill.transform.GetChild(i).GetComponent<EnemyData>().SpawnTime);
                e_fill.transform.GetChild(i).SetParent(e_empty.transform);
            }
            Destroy(e_fill);
        }
    }
}
