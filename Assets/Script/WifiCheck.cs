using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WifiCheck : MonoBehaviour
{
    public GameObject noWifiTab;
    public bool check() {
        if (Application.internetReachability == NetworkReachability.NotReachable) {
            return false;
        } else {
            return true;
        }
    }
    public void goDownload() {
        if (check()) {
            SceneManager.LoadScene("mapDownload");
        } else {
            noWifiTab.SetActive(true);
            for (int i = 0; i < noWifiTab.transform.childCount; i++) noWifiTab.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
