using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapObjSummon : MonoBehaviour {
    public GameObject baseEnemy;
    private Image image;
    private SpriteRenderer SpriteRenderer;
    private Sprite currentSprite;
    private Color currentColor;
    private GameObject[,] aaa;
    private List<GameObject> list;
    
    private void Start()
    {
        /*list = new List<GameObject>();
        
        list.Add(baseEnemy);
        list.Remove(baseEnemy);
        list.Contains(baseEnemy);
        int a = list.Count;
        for(int i=0; i < list.Count; i++)
        {
            Instantiate(list[i]);
        }*/
        image = gameObject.GetComponent<Image>();
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        currentSprite = image.sprite;
        currentColor = image.color;
    }
    public void Summon()
    {
        GameObject newObject = Instantiate(baseEnemy) as GameObject;
        newObject.transform.localScale = new Vector3(1, 1, 1);
        newObject.transform.localPosition = new Vector3(0,0,1);
        newObject.GetComponent<SpriteRenderer>().sprite = currentSprite;
        newObject.GetComponent<SpriteRenderer>().color = currentColor;

        Debug.Log("AA");
    }
    /*private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
     }*/
   
}
