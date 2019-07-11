using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXYItem : MonoBehaviour
{
    public GameObject TouchScreen;
    // Start is called before the first frame update
    void Start()
    {
        TouchScreen = GameObject.Find("sendGameObject").GetComponent<SendGameObject>().TouchScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getTouch() {
        TouchScreen.SetActive(true);
        TouchScreen.GetComponent<GetTouchXY>().getTouch(this.gameObject);
    }
    public void delete() {
        Destroy(this.gameObject);
    }
}
