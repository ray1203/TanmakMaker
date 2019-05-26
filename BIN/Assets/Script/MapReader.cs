﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
public class MapReader : MonoBehaviour
{
    public InputField mapNameInput;
    string m_strPath = "map/";
    public GameObject ContentUI;
    public GameObject Content;
    public GameObject warn;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.platform);
        Debug.Log(Application.dataPath);
        m_strPath=PathForDocumentsFile(m_strPath);
        DirectoryInfo di = new DirectoryInfo(m_strPath);
        if (di.Exists == false) {
            di.Create();
        }
        if (GameObject.FindWithTag("MapName")) Destroy(GameObject.FindWithTag("MapName"));
        if (GameObject.FindWithTag("fill")) Destroy(GameObject.FindWithTag("fill"));
        reloadmap();
    }
    public void reloadmap() {
        foreach(var Item in GameObject.FindGameObjectsWithTag("mapcontent")) {
            Destroy(Item);
        }
        RectTransform rt = Content.GetComponent<RectTransform>();
        int c = 0;
        int FileCount = 0;
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(m_strPath);
        
        foreach (var Item in di.GetFiles()) {
            if (!Item.Name.Contains(".meta")) {
                FileCount++;
            }
        }
        foreach (var Item in di.GetFiles()) {
            if (Item.Name.Contains(".meta")) continue;
            GameObject newObject = ContentUI;
            List<EnemyData> enemyDatas = new List<EnemyData>();
            newObject.transform.Find("mapname").GetComponent<Text>().text = Item.Name.Replace(".txt", "");
            //TextAsset data = Resources.Load(Item.Name.Replace(".txt", ""), typeof(TextAsset)) as TextAsset;
            //TextAsset data = AssetDatabase.LoadAssetAtPath(m_strPath + "/" + Item.Name, typeof(TextAsset))as TextAsset;
            //Debug.Log(data);
            //if (data != null) {
            //StringReader sr = new StringReader(data.text);
            StreamReader sr = Item.OpenText();
                string source = sr.ReadLine();
                while (source != null) {
                    string[] values;
                    values = source.Split(',');
                    if (values.Length == 0) {
                        sr.Close();
                        return;
                    }
                    enemyDatas.Add(new EnemyData(new Vector2(float.Parse(values[0]), float.Parse(values[1])), new Vector2(float.Parse(values[2]), float.Parse(values[3])), new Vector2(float.Parse(values[4]), float.Parse(values[5])), float.Parse(values[6]), float.Parse(values[7]), int.Parse(values[8]), float.Parse(values[9]), float.Parse(values[10]), new Color(float.Parse(values[11]), float.Parse(values[12]), float.Parse(values[13])), null, null));
                    source = sr.ReadLine();    // 한줄 읽는다.
                }
           // }
            rt.sizeDelta = new Vector2(rt.sizeDelta.x * 3.6f, 100 * (c+1) * 3.6f);
            newObject = Instantiate(newObject);
            newObject.GetComponent<mapData>().EnemyDatas = enemyDatas;
            newObject.transform.SetParent(Content.transform);
            newObject.transform.localPosition = new Vector3(0f, (-75+FileCount*50-100 * (c++))*3.6f, 0);
            newObject.transform.localScale = new Vector3(1f, 1f, 1f);
            newObject.transform.tag = "mapcontent";
            //if (rt.sizeDelta.y < 50 * c)
            sr.Close();
        }
    }
    public void makemap() {
        if (!File.Exists(m_strPath + mapNameInput.text+".txt")) {
            File.Create(m_strPath + mapNameInput.text+".txt");

        }
    }
    public void reloadScene() {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
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
        } else if(Application.platform == RuntimePlatform.WindowsEditor) {
            string path = Application.dataPath + "/" + filename;
            return path;
        } else if(Application.platform == RuntimePlatform.WindowsPlayer) {
            string path = Application.dataPath+"/"+filename;
            return path;
        } else {
            string path = Application.dataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
