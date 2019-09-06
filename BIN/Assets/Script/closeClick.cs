using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool flag = false;
    float t = 0f;
    // Update is called once per frame
    void Update()
    {
        if (!flag) {
            t += Time.deltaTime;
            if (t > 2f) { flag = true;  }
        }
        if (flag&&Input.touchCount != 0||flag&&Input.GetMouseButtonDown(0)) {
            for(int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(false);
                t = 0f;
                flag = false;
            }
            gameObject.SetActive(false);
        }
    }
}
