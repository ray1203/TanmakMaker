using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjSummon : MonoBehaviour {
    public GameObject baseEnemy;
    private SpriteRenderer spriteRenderer;
    private Sprite currentSprite;
    private Color currentColor;
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        currentSprite = spriteRenderer.sprite;
        currentColor = spriteRenderer.color;
    }
    private void OnMouseDown()
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
