using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase;
public class MapUpload : MonoBehaviour
{
    private GameObject uploadTab;
    public GameObject uploadName;
    public GameObject description;
    public GameObject showMapCodeTab;
    public List<EnemyData> enemyDatas;
    public int mapCode = -1;
    public string mapName = null;
    private static RealTimeDatabase Instance;
    public DatabaseReference reference;
    void Awake() {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://shootinggame1203.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    public void openTab() {
        uploadTab = GameObject.Find("Canvas").transform.Find("background").transform.Find("mapUpload").gameObject;
        uploadTab.SetActive(true);
        for(int i = 0; i < uploadTab.transform.childCount; i++) {
            uploadTab.transform.GetChild(i).gameObject.SetActive(true);
            if (uploadTab.transform.GetChild(i).tag == "MapName") {
                uploadTab.transform.GetChild(i).name= this.transform.Find("mapname").GetComponent<Text>().text;
            }
        }
        uploadTab.GetComponent<MapUpload>().enemyDatas = gameObject.GetComponent<mapData>().enemyDatas;
        uploadTab.transform.Find("Image").Find("UploadName").GetComponent<InputField>().text = "";
        uploadTab.transform.Find("Image").Find("Description").GetComponent<InputField>().text = "";

    }
    public void upload() {

        if (uploadName.GetComponent<InputField>().text == "" || description.GetComponent<InputField>().text=="") return;
        
        string m_strPath = "map/";
        string uploadNameStr =  uploadName.GetComponent<InputField>().text;
        string descriptionStr = description.GetComponent<InputField>().text;
        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).tag == "MapName") {
                mapName = transform.GetChild(i).name;
            }
        }
        // FirebaseDatabase.DefaultInstance.GetReference("map").Child("mapCode")
        m_strPath = m_strPath + mapName + ".txt";
        m_strPath = PathForDocumentsFile(m_strPath);
        string[] value = System.IO.File.ReadAllLines(m_strPath);

        reference.Child("map").Child("mapcode").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted) {
                    Debug.Log("failed");
                } else if (task.IsCompleted) {
                    DataSnapshot snapshot = task.Result;
                    mapCode = int.Parse(snapshot.Value.ToString())+1;
                    reference.Child("map").Child("mapcode").SetValueAsync(mapCode.ToString());
                    //reference.Child("map").Child(mapCode.ToString()).SetValueAsync("1");
                    reference.Child("map").Child(mapCode.ToString()).Child("mapName").SetValueAsync(uploadNameStr);
                    reference.Child("map").Child(mapCode.ToString()).Child("description").SetValueAsync(descriptionStr);
                    reference.Child("map").Child(mapCode.ToString()).Child("accessCount").SetValueAsync(0);
                    reference.Child("map").Child(mapCode.ToString()).Child("mapData").Child("dataCount").SetValueAsync(value.Length);
                    for (int i = 0; i < value.Length; i++) {
                        reference.Child("map").Child(mapCode.ToString()).Child("mapData").Child(i.ToString()).SetValueAsync(value[i]);
                    }
                /*reference.Child("map").Child("11").SetValueAsync("test");
                reference.Child("map").Child("11").Child("mapName").SetValueAsync(uploadName.GetComponent<InputField>().text);
                reference.Child("map").Child("11").Child("description").SetValueAsync(description.GetComponent<InputField>().text);
                reference.Child("map").Child("11").Child("accessCount").SetValueAsync(0);
                reference.Child("map").Child("11").Child("mapData").Child("dataCount").SetValueAsync(value.Length);*/
            }
            });

        StartCoroutine(SomeCoroutine());
        showMapCode(mapCode, mapName);
        gameObject.SetActive(false);


    }
    public void showMapCode(int mapCode,string mapName) {
        showMapCodeTab.gameObject.SetActive(true);
        for(int i = 0; i < showMapCodeTab.transform.childCount; i++) {
            showMapCodeTab.transform.GetChild(i).gameObject.SetActive(true);
            showMapCodeTab.transform.Find("Image").Find("InputField").GetComponent<InputField>().text = mapCode.ToString();
            showMapCodeTab.transform.Find("Image").Find("Text (1)").GetComponent<Text>().text = mapName+ "의 맵코드는";
        }
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
    IEnumerator SomeCoroutine() {
        Debug.Log("Start Coroutine");
        yield return new WaitForSeconds(1000f);
        Debug.Log("Waited!");
        yield return null;
        Debug.Log("End Coroutine!");
    }
}
