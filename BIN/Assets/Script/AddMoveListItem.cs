using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddMoveListItem : MonoBehaviour
{
    public GameObject Content;
    public GameObject MoveXY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddItem() {
        GameObject gameObject = Instantiate(MoveXY)as GameObject;
        gameObject.transform.localScale = new Vector3(1/160f,1/160f, 1);
        gameObject.transform.SetParent(Content.transform);
    }
    public void AddItem(Vector2 pos) {
        GameObject gameObject = Instantiate(MoveXY) as GameObject;
        gameObject.transform.localScale = new Vector3(1 / 160f, 1 / 160f, 1);
        gameObject.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text = "" + pos.x;
        gameObject.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text = "" + pos.y;
        gameObject.transform.SetParent(Content.transform);
    }
}
