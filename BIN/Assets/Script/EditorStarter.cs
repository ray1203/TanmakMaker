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
                Transform c = e_fill.transform.GetChild(0);
                slider.GetComponent<TimeSelect>().MaxSummonTime(c.GetComponent<EnemyData>().SpawnTime);
                c.transform.position = (c.GetComponent<EnemyData>().Pos[0]);
                c.SetParent(e_empty.transform);
                c.localScale = new Vector3(1f, 1f, 0f);

            }
            Destroy(e_fill);
        }
        
    }
}
