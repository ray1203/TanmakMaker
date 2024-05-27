using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Android;
public class OpenFolder : MonoBehaviour
{
    // Start is called before the first frame update
    string m_strPath = "map/";
    void Start()
    {
        m_strPath = PathForDocumentsFile(m_strPath);
    }
    public void openFolder() {
        if (Application.platform == RuntimePlatform.Android) {
            //Application.OpenURL("Phone\\Android\\data\\com.ray1203.ShootingGame\\map");
            Application.OpenURL("file:///storage/emulated/0/Android/data/com.ray1203.ShootingGame/map/");
            //System.Diagnostics.Process.Start("Samsung My Files.apk", m_strPath);
        } else Application.OpenURL(m_strPath);
       // }
       // 
    }
    // Update is called once per frame
    void Update()
    {
        
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
