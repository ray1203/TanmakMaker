using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class MapReader : MonoBehaviour
{
    string m_strPath = "Assets/Resources/";
    public GameObject Content;
    // Start is called before the first frame update
    void Start()
    {
        int c = 0;
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(m_strPath);
        foreach(var Item in di.GetFiles()) {
            if (Item.Name.Contains("meta")) continue;
            GameObject newObject = Content;
            List<EnemyData> enemyDatas = new List<EnemyData>();
            newObject.transform.Find("mapname").GetComponent<Text>().text = Item.Name;
            TextAsset data = Resources.Load(Item.Name.Replace(".txt",""),typeof(TextAsset))as TextAsset;
            Debug.Log(data);
            StringReader sr = new StringReader(data.text);
            string source = sr.ReadLine();
            Debug.Log(source);
            while (source != null) {
                string[] values;
                values = source.Split(',');
                if (values.Length == 0) {
                    sr.Close();
                    return;
                }
                enemyDatas.Add(new EnemyData(new Vector2(float.Parse(values[0]), float.Parse(values[1])), new Vector2(float.Parse(values[2]), float.Parse(values[3])), new Vector2(float.Parse(values[4]), float.Parse(values[5])),float.Parse(values[6]), float.Parse(values[7]),int.Parse(values[8]), float.Parse(values[9]), float.Parse(values[10]), new Color(float.Parse(values[11]), float.Parse(values[12]), float.Parse(values[13])),null,null));
                source = sr.ReadLine();    // 한줄 읽는다.
            }
            newObject.GetComponent<mapData>().EnemyDatas = enemyDatas;
            newObject=Instantiate(newObject);
            newObject.transform.SetParent(GameObject.Find("Content").transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
