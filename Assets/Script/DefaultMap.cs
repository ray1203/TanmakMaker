using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;

public class DefaultMap : MonoBehaviour {
    void Awake() {
        int c = 0;
        string m_strPath = "map/";
        if (Application.platform == RuntimePlatform.IPhonePlayer) {
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
            path = path.Substring(0, path.LastIndexOf('/'));
            m_strPath = Path.Combine(Path.Combine(path, "Documents"), m_strPath);
        } else if (Application.platform == RuntimePlatform.Android) {
            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            m_strPath = Path.Combine(path, m_strPath);
        } else if (Application.platform == RuntimePlatform.WindowsEditor) {
            string path = Application.dataPath + "/" + m_strPath;
            m_strPath = path;
        } else if (Application.platform == RuntimePlatform.WindowsPlayer) {
            string path = Application.dataPath + "/" + m_strPath;
            m_strPath = path;
        } else {
            string path = Application.dataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            m_strPath = Path.Combine(path, m_strPath);
        }
        foreach (var item in Resources.LoadAll("DefaultMap", typeof(TextAsset))) {
            if (PlayerPrefs.GetInt(item.name+"_1", 0) == 1) {
                Resources.UnloadAsset(item);
                continue;
            }
            if (File.Exists(m_strPath + "/" + item.name + ".txt")) {
                Resources.UnloadAsset(item);
                continue;
            }
            TextAsset text = (TextAsset)item;
            File.WriteAllBytes(m_strPath + "/" + item.name + ".txt", text.bytes);
            PlayerPrefs.SetInt(item.name+"_1", 1);
            Resources.UnloadAsset(item);
            c++;

        }
        //if(c>0)SceneManager.LoadScene("MainMenu");
    }
    
}
