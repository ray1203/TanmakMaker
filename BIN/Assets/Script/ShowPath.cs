using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class ShowPath : MonoBehaviour
{
    public InputField input;
    
    public void show() {
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
        input.text = m_strPath;
    }
}
