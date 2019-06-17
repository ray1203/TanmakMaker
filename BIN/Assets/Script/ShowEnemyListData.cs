using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowEnemyListData : MonoBehaviour
{
    public GameObject editingEnemy;
    // Start is called before the first frame update
    void Start()
    {
        EnemyData e = editingEnemy.GetComponent<EnemyData>();
        this.transform.Find("Text").GetComponent<Text>().text = "소환 위치  x:" + e.SpawnPoint.x + "  y:" + e.SpawnPoint.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void open() {
        editingEnemy.GetComponent<EnemyEdit>().edit();
    }
}
