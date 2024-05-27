using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnemyByTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void show(int time) {
        for (int i = 0; i < this.transform.childCount; i++) {
            if((int)Mathf.Floor(this.transform.GetChild(i).GetComponent<EnemyData>().SpawnTime)==time) this.transform.GetChild(i).gameObject.SetActive(true);
            else this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
