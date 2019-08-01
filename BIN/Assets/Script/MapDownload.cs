using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase;

public class MapDownload : MonoBehaviour {
    public GameObject wifiTab;
    public GameObject mapCodeTab;
    public string mapName;
    public string mapDescription;
    public string mapAccessCount;
    public List<string> mapDatas;
    public GameObject successTab;
    public int searchFlag = 0;//0:기본 1:실패
    string m_strPath = "map/";
    private static RealTimeDatabase Instance;
    public DatabaseReference reference;
    int dataCount;
    void Awake() {
        List<string> mapDatas=new List<string>();
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://shootinggame1203.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        m_strPath = PathForDocumentsFile(m_strPath);
        DirectoryInfo di = new DirectoryInfo(m_strPath);
        if (di.Exists == false) {
            di.Create();
        }
    }
    public void search() {
        if (Application.internetReachability == NetworkReachability.NotReachable) {
            wifiTab.SetActive(true);
            for (int i = 0; i < wifiTab.transform.childCount; i++) wifiTab.transform.GetChild(i).gameObject.SetActive(true);
        }
        mapDatas = new List<string>();
        string mapCode = mapCodeTab.GetComponent<InputField>().text;
        if (mapCode == "") return;
        reference.Child("map").Child(mapCode).GetValueAsync().ContinueWith(task1 => {
            if (task1.Result.Value == null) {
                searchFlag = 1;
                return;
            } else if (task1.IsCompleted) {
                reference.Child("map").Child(mapCode).Child("mapName").GetValueAsync().ContinueWith(task2 => {
                    if (task2.IsFaulted) {
                        Debug.Log("error:mapName");
                        return;
                    } else if (task2.IsCompleted) {
                        DataSnapshot snapshot = task2.Result;
                        mapName = snapshot.Value.ToString();
                    }
                });
                reference.Child("map").Child(mapCode).Child("description").GetValueAsync().ContinueWith(task2 => {
                    if (task2.IsFaulted) {
                        Debug.Log("error:description");
                        return;
                    } else if (task2.IsCompleted) {
                        DataSnapshot snapshot = task2.Result;
                        mapDescription = snapshot.Value.ToString();

                    }
                });

                reference.Child("map").Child(mapCode).Child("mapData").Child("dataCount").GetValueAsync().ContinueWith(task2 => {
                if (task2.IsFaulted) {
                        Debug.Log("error:mapData");
                        return;
                } else if (task2.IsCompleted) {
                        DataSnapshot snapshot = task2.Result;
                        dataCount = int.Parse(snapshot.Value.ToString());
                        for (int i = 0; i < dataCount; i++) {
                            reference.Child("map").Child(mapCode).Child("mapData").Child(i.ToString()).GetValueAsync().ContinueWith(task3 => {
                                if (task3.IsFaulted) {
                                    Debug.Log("error:mapData:"+i);
                                    return;
                                } else if (task3.IsCompleted) {
                                    DataSnapshot snapshot2 = task3.Result;
                                    mapDatas.Add(snapshot2.Value.ToString());

                                }
                            });
                        }
                        
                    }
                });

                reference.Child("map").Child(mapCode).Child("accessCount").GetValueAsync().ContinueWith(task2 => {
                    if (task2.IsFaulted) {
                        Debug.Log("error:accessCount");
                        return;
                    } else if (task2.IsCompleted) {
                        DataSnapshot snapshot = task2.Result;
                        reference.Child("map").Child(mapCode).Child("accessCount").SetValueAsync((int.Parse(snapshot.Value.ToString())+1).ToString());
                        mapAccessCount = snapshot.Value.ToString();


                    }
                });
            } else {
                Debug.Log("error:mapCode");

            }
        });

    }
    public void download() {
        if (!File.Exists(m_strPath + mapName + ".txt")) {
            for (int i = 0; i < dataCount; i++) {
                if (mapDatas[i].Contains("MAP_VERSION")) {
                    string str = mapDatas[0];
                    mapDatas[0] = mapDatas[i];
                    mapDatas[i] = str;
                    break;
                }
            }
            Debug.Log("success");
            //File.Create(m_strPath + mapNameInput.text+".txt");
            string path = m_strPath;
            path = path + mapName + ".txt";
            FileStream fs = new FileStream(path, FileMode.Create);

            StreamWriter w = new StreamWriter(fs);
            for(int i = 0; i < mapDatas.Count; i++) {
                w.WriteLine(mapDatas[i]);
            }
            w.Close();
            StartCoroutine(Success());
            return;


        } else {
            int count = 1;
            while (true) {
                if (!File.Exists(m_strPath + mapName + "(" + count + ")" + ".txt")) {
                    Debug.Log("success:"+count);
                    string path = m_strPath;
                    path = path + mapName + "(" + count + ")" + ".txt";
                    FileStream fs = new FileStream(path, FileMode.Create);

                    StreamWriter w = new StreamWriter(fs);
                    for (int i = 0; i < mapDatas.Count; i++) {
                        w.WriteLine(mapDatas[i]);
                    }
                    w.Close();
                    StartCoroutine(Success());
                    return;

                }
                count++;
            }
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
    IEnumerator Success() {
        successTab.SetActive(true);
        for (int i = 0; i <= successTab.transform.childCount; i++) successTab.transform.GetChild(i).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        successTab.SetActive(false);
    }
}
