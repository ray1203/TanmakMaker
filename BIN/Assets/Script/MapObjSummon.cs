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
    public Sprite EnemySprite;
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
        newObject.rectTransform.SetParent(canvas.transform.Find("background").Find("Enemy"));
        //newObject.transform.localScale = new Vector3(0.1f, 0.1f, 1);
        newObject.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        //newObject.transform.position = new Vector3(0f,0f,0f);
        //newObject.rectTransform.position= new Vector3(0f, 0f, 0f);
        newObject.gameObject.transform.position=new Vector3(0f, 0f, 0f);
        newObject.GetComponent<Image>().sprite = EnemySprite;
        newObject.GetComponent<Image>().color = currentColor;
        newObject.GetComponent<EnemyData>().SpawnTime = canvas.transform.Find("background").Find("Slider").GetComponent<TimeSelect>().GetValue();
        newObject.GetComponent<EnemyData>().EnemySpeed = 1f;
        newObject.GetComponent<EnemyData>().Firerate = 1f;
        newObject.GetComponent<EnemyData>().BulletSpeed = 1f;
        newObject.GetComponent<EnemyData>().Hp = 1;
        newObject.GetComponent<EnemyData>().EnemySprite = EnemySprite;
        List<Vector2> posList = new List<Vector2>();
        posList.Add(new Vector2(0f, 0f));
        newObject.GetComponent<EnemyData>().Pos = posList;
        //newObject.GetComponent<EnemyData>().Color = this.GetComponent<Image>().color;
        //newObject.transform.parent=canvas.transform.Find("Enemy");
    }
    /*private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
     }*/
   
}
