using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIclose : MonoBehaviour {
    private GameObject enemy;
    private GameObject Enemy;//enemy가 저장되어 모여있는 오브젝트
    public GameObject summonTime, summonxy, firstmovexy, secondmovexy, movespeed, firerate, bullettype, bulletspeed,spreadpoint;
    private EnemyData enemyData;
    public Slider slider;
    public GameObject ClickBan;
    private Camera subCamera;
    void Start() {
        //subCamera = GameObject.FindWithTag("SubCamera").GetComponent<Camera>();
        Enemy = GameObject.Find("Enemy");
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
        spreadpoint.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.SpreadPoint;
        ClickBan.SetActive(true);
        GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable = false;
    }
    public void closeEnemyOption() {
        enemyData.SpawnTime = float.Parse(summonTime.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        if (enemyData.SpawnTime < 0) enemyData.SpawnTime = 0;
        else if (enemyData.SpawnTime > 3600) enemyData.SpawnTime = 3600;
        slider.GetComponent<TimeSelect>().MaxSummonTime(enemyData.SpawnTime);
        enemyData.SpawnPoint = new Vector2(float.Parse(summonxy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text), float.Parse(summonxy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text));
        enemyData.Pos1 = new Vector2(float.Parse(firstmovexy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text), float.Parse(firstmovexy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text));
        enemyData.Pos2 = new Vector2(float.Parse(secondmovexy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text), float.Parse(secondmovexy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text));
        enemyData.EnemySpeed = float.Parse(movespeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Firerate = float.Parse(firerate.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Bullettype = bullettype.transform.Find("Dropdown").gameObject.GetComponent<Dropdown>().value;
        enemyData.BulletSpeed = float.Parse(bulletspeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.SpreadPoint = int.Parse(spreadpoint.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        if (enemyData.SpreadPoint > 30) enemyData.SpreadPoint = 30;
        enemy.gameObject.transform.position = enemyData.SpawnPoint;

        for (int i = 0; i < this.transform.childCount; i++) {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
        ClickBan.SetActive(false);
        GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable = true;
        Enemy.GetComponent<ShowEnemyByTime>().show((int)slider.value);
        this.gameObject.SetActive(false);
    }
    public void deleteEnemy() {
        GameObject enemys;
        float enemyTime = 0f;
        enemyTime = enemy.GetComponent<EnemyData>().SpawnTime;
        enemys = GameObject.Find("Enemy");
        TimeSelect timeSelect = slider.GetComponent<TimeSelect>();
        
        ClickBan.SetActive(false);
        GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable = true;
        timeSelect.resetValue();
        for (int i = 0; i < enemys.transform.childCount; i++) {
            float t = enemys.transform.GetChild(i).GetComponent<EnemyData>().SpawnTime;
            if (enemyTime==t) {
                enemyTime = -1;
                continue;
            }
            timeSelect.MaxSummonTime(t);

        }
        Destroy(enemy);
        
        close();
            
                
            
            
        
        
    }
    public void copyEnemy() {
        
        GameObject newObject = Instantiate(enemy);
        newObject.name = enemy.name;
        newObject.transform.SetParent(Enemy.transform);
        newObject.transform.localScale = enemy.transform.localScale;
        EnemyData enemyData = newObject.GetComponent<EnemyData>();
        enemyData.SpawnTime = float.Parse(summonTime.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        if (enemyData.SpawnTime < 0) enemyData.SpawnTime = 0;
        else if (enemyData.SpawnTime > 3600) enemyData.SpawnTime = 3600;
        slider.GetComponent<TimeSelect>().MaxSummonTime(enemyData.SpawnTime);
        enemyData.SpawnPoint = new Vector2(float.Parse(summonxy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text), float.Parse(summonxy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text));
        enemyData.Pos1 = new Vector2(float.Parse(firstmovexy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text), float.Parse(firstmovexy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text));
        enemyData.Pos2 = new Vector2(float.Parse(secondmovexy.transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text), float.Parse(secondmovexy.transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text));
        enemyData.EnemySpeed = float.Parse(movespeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Firerate = float.Parse(firerate.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Bullettype = bullettype.transform.Find("Dropdown").gameObject.GetComponent<Dropdown>().value;
        enemyData.BulletSpeed = float.Parse(bulletspeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.SpreadPoint = int.Parse(spreadpoint.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        newObject.gameObject.transform.position = enemyData.SpawnPoint;
        Enemy.GetComponent<ShowEnemyByTime>().show((int)slider.value);
    }
}
