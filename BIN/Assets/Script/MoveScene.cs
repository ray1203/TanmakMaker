using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
    public void startTest(string name) {
        GameObject e = GameObject.Find("Enemy");
        e.transform.parent = null;
        DontDestroyOnLoad(e.gameObject);
        SceneManager.LoadScene(name);
    }
    
}
