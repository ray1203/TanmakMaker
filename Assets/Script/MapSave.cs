using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class MapSave : MonoBehaviour
{
    public GameObject enemy;
    private string m_strPath= "map/";
    // Start is called before the first frame update
    void Start() {
        m_strPath = PathForDocumentsFile(m_strPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void save() {
        string mapName = GameObject.FindWithTag("MapName").name+".txt";
        string path = m_strPath;
        path = path + mapName;
        FileStream fs = new FileStream(path, FileMode.Create);
     
        StreamWriter w = new StreamWriter(fs);
        w.WriteLine("MAP_VERSION:1");
        for(int i = 0; i < enemy.transform.childCount; i++) {
            EnemyData e = enemy.transform.GetChild(i).GetComponent<EnemyData>();
            int loop;
            if (e.Loop) loop = 1; else loop = 0;
            string str = e.SpawnTime+","+e.EnemySpeed+","+e.Bullettype+","+e.Firerate+","+e.BulletSpeed+"," + e.BulletSize + "," + e.SpreadPoint+","+e.Hp + "," + e.MaintainTime+ "," + e.SpreadAngle + "," + e.Score + "," +loop;
            for (int j = 0; j < e.Pos.Count; j++) {
                str = str + "," + e.Pos[j].x + "," + e.Pos[j].y;
                
            }
            w.WriteLine(str);
        }
        w.Close();
        m_strPath = "map/";
        m_strPath = PathForDocumentsFile(m_strPath);
    }
    public void delete() {
        string mapName = GameObject.FindWithTag("MapName").name + ".txt";
        string path = m_strPath;
        path = path + mapName;
        if (File.Exists(path)) {
            System.IO.File.Delete(path);
        }
        m_strPath = "map/";
        m_strPath = PathForDocumentsFile(m_strPath);

    }
    public void delete_warning() {
        GameObject warn=GameObject.Find("background").GetComponent<MapReader>().warn;
        
        for (int i = 0; i < warn.transform.childCount; i++) {
            warn.transform.GetChild(i).gameObject.SetActive(true);
        }
        warn.gameObject.SetActive(true);
        GameObject.FindWithTag("MapName").name= this.transform.Find("mapname").GetComponent<Text>().text;
    }
    public string PathForDocumentsFile(string filename) {
        if (Application.platform == RuntimePlatform.IPhonePlayer) {
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(Path.Combine(path, "Documents"), filename);
        } else if (Application.platform == RuntimePlatform.Android) {
            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        } else if (Application.platform == RuntimePlatform.WindowsEditor) {
            string path = Application.dataPath + "/" + filename;
            return path;
        } else if (Application.platform == RuntimePlatform.WindowsPlayer) {
            string path = Application.dataPath + "/" + filename;
            return path;
        } else {
            string path = Application.dataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }
    }
}
