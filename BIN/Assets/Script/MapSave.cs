using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapSave : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void save() {
        string m_strPath = "Assets/Resources/";
        string mapName = GameObject.FindWithTag("MapName").name+".txt";
        FileStream fs = new FileStream(m_strPath + mapName, FileMode.Create);
        StreamWriter w = new StreamWriter(fs);
        for(int i = 0; i < enemy.transform.childCount; i++) {
            EnemyData e = enemy.transform.GetChild(i).GetComponent<EnemyData>();
            string str = e.SpawnPoint.x + "," + e.SpawnPoint.y + ","+e.Pos1.x+","+e.Pos1.y+","+ e.Pos2.x + "," + e.Pos2.y + "," +e.SpawnTime+","+e.EnemySpeed+","+e.Bullettype+","+e.Firerate+","+e.BulletSpeed+","+e.Color.r+","+e.Color.g+","+e.Color.b+","+null+","+null;
            w.WriteLine(str);
        }
        w.Close();
    }
}
