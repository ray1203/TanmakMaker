using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
    public void startTest(string name) {
        GameObject e = GameObject.Find("Enemy");
        e.tag = "fill";
        e.transform.SetParent(null);
        for(int i = 0; i < e.transform.childCount; i++) {
            e.transform.GetChild(i).gameObject.SetActive(false);
        }
        DontDestroyOnLoad(e.gameObject);
        SceneManager.LoadScene(name);
    }
    

}
