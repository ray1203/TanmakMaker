using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount != 0||Input.GetMouseButtonDown(0)) {
            for(int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }
}
