using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MapReader : MonoBehaviour
{
    public InputField mapNameInput;
    string m_strPath = "Assets/Resources/";
    public GameObject ContentUI;
    public GameObject Content;
    // Start is called before the first frame update
    void Start()
    {
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
            TextAsset data = Resources.Load(Item.Name.Replace(".txt", ""), typeof(TextAsset)) as TextAsset;
            Debug.Log("Data:"+data);
            if (data != null) {
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
                    enemyDatas.Add(new EnemyData(new Vector2(float.Parse(values[0]), float.Parse(values[1])), new Vector2(float.Parse(values[2]), float.Parse(values[3])), new Vector2(float.Parse(values[4]), float.Parse(values[5])), float.Parse(values[6]), float.Parse(values[7]), int.Parse(values[8]), float.Parse(values[9]), float.Parse(values[10]), new Color(float.Parse(values[11]), float.Parse(values[12]), float.Parse(values[13])), null, null));
                    source = sr.ReadLine();    // 한줄 읽는다.
                }
                newObject.GetComponent<mapData>().EnemyDatas = enemyDatas;
            }
                rt.sizeDelta = new Vector2(rt.sizeDelta.x, 100 * (c+1));
            newObject = Instantiate(newObject);
            newObject.transform.SetParent(Content.transform);
            newObject.transform.localPosition = new Vector3(0f, -75+FileCount*50-100 * (c++), 0);
            newObject.transform.localScale = new Vector3(1f, 1f, 1f);
            newObject.transform.tag = "mapcontent";
            //if (rt.sizeDelta.y < 50 * c)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
