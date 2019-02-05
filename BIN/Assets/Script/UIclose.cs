using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIclose : MonoBehaviour {
    private GameObject enemy;
    public GameObject summonTime, summonxy, firstmovexy, secondmovexy, movespeed, firerate, bullettype, bulletspeed;
    private EnemyData enemyData;
    public Slider slider;
    public GameObject ClickBan;
    void Start() {
    }
	public void close()
    {
        for (int i = 0; i <this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
    public void open()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
        this.gameObject.SetActive(true);
    }
    public void openEnemyOption(GameObject gameObject) {
        this.enemy = gameObject;
        enemyData= enemy.transform.GetComponent<EnemyData>();
        this.gameObject.SetActive(true);
        for (int i = 0; i < this.transform.childCount; i++) {
            if (this.transform.GetChild(i).gameObject.name == "TouchScreen") continue;
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
        summonTime.transform.Find("InputField").gameObject.GetComponent<InputField>().text = ""+enemyData.SpawnTime;
        summonxy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text= "" + enemyData.SpawnPoint.x;
        summonxy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text = "" + enemyData.SpawnPoint.y;
        firstmovexy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text = "" + enemyData.Pos1.x;
        firstmovexy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text = "" + enemyData.Pos1.y;
        secondmovexy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text = "" + enemyData.Pos2.x;
        secondmovexy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text = "" + enemyData.Pos2.y;
        movespeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.EnemySpeed;
        firerate.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.Firerate;
        bullettype.transform.Find("Dropdown").gameObject.GetComponent<Dropdown>().value = enemyData.Bullettype;
        bulletspeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.BulletSpeed;
        ClickBan.SetActive(true);
        GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable = false;
    }
    public void closeEnemyOption() {
        enemyData.SpawnTime = float.Parse(summonTime.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        slider.GetComponent<TimeSelect>().MaxSummonTime(enemyData.SpawnTime);
        enemyData.SpawnPoint = new Vector2(float.Parse(summonxy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text), float.Parse(summonxy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text));
        enemyData.Pos1 = new Vector2(float.Parse(firstmovexy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text), float.Parse(firstmovexy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text));
        enemyData.Pos2 = new Vector2(float.Parse(secondmovexy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text), float.Parse(secondmovexy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text));
        enemyData.EnemySpeed = float.Parse(movespeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Firerate = float.Parse(firerate.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Bullettype = bullettype.transform.Find("Dropdown").gameObject.GetComponent<Dropdown>().value;
        enemyData.BulletSpeed = float.Parse(bulletspeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemy.gameObject.transform.position = Camera.main.ScreenToWorldPoint(enemyData.SpawnPoint);
        for (int i = 0; i < this.transform.childCount; i++) {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
        ClickBan.SetActive(false);
        GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable = true;
        this.gameObject.SetActive(false);
    }
}
