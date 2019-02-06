using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapObjSummon : MonoBehaviour {
    public Image baseEnemy;
    private Image image;
    private SpriteRenderer SpriteRenderer;
    private Sprite currentSprite;
    private Color currentColor;
    private GameObject[,] aaa;
    private List<GameObject> list;
    private GameObject canvas;
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
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
        Image newObject = Instantiate(baseEnemy) as Image;
        //newObject.transform.localScale = new Vector3(0.1f, 0.1f, 1);
        newObject.rectTransform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        //newObject.transform.position = new Vector3(0f,0f,0f);
        //newObject.rectTransform.position= new Vector3(0f, 0f, 0f);
        newObject.gameObject.transform.position=new Vector3(0f, 0f, 0f);
        newObject.GetComponent<Image>().sprite = currentSprite;
        newObject.GetComponent<Image>().color = currentColor;
        newObject.GetComponent<EnemyData>().SpawnTime = canvas.transform.Find("Slider").GetComponent<TimeSelect>().GetValue();
        newObject.GetComponent<EnemyData>().EnemySprite = this.GetComponent<Image>().sprite;
        newObject.GetComponent<EnemyData>().Color = this.GetComponent<Image>().color;
        //newObject.transform.parent=canvas.transform.Find("Enemy");
        newObject.rectTransform.SetParent(canvas.transform.Find("Enemy"));
    }
    /*private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
     }*/
   
}
