using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIclose : MonoBehaviour {
    private GameObject enemy;
    public GameObject summonTime, summonxy, firstmovexy, secondmovexy, movespeed, firerate, bullettype, bulletspeed;
    private EnemyData enemyData;
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
    }
    public void closeEnemyOption() {
        enemyData.SpawnTime = float.Parse(summonTime.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.SpawnPoint = new Vector2(float.Parse(summonxy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text), float.Parse(summonxy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text));

        for (int i = 0; i < this.transform.childCount; i++) {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
}
