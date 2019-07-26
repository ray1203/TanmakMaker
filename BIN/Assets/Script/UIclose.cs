using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIclose : MonoBehaviour {
    private GameObject enemy;
    private GameObject Enemy;//enemy가 저장되어 모여있는 오브젝트
    public GameObject summonTime, movespeed, firerate, bullettype, bulletspeed,spreadpoint,hp,pos,addPos,enemyScore,spreadAngle,maintainTime,loop,bulletSize;
    private EnemyData enemyData;
    public Slider slider;
    public GameObject ClickBan;
    public GameObject EnemyListWindow;
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
        movespeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.EnemySpeed;
        firerate.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.Firerate;
        bullettype.transform.Find("Dropdown").gameObject.GetComponent<Dropdown>().value = enemyData.Bullettype;
        bulletspeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.BulletSpeed;
        spreadpoint.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.SpreadPoint;
        enemyScore.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.Score;
        hp.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.Hp;
        spreadAngle.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.SpreadAngle;
        maintainTime.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.MaintainTime;
        bulletSize.transform.Find("InputField").gameObject.GetComponent<InputField>().text = "" + enemyData.BulletSize;
        loop.transform.Find("Toggle").gameObject.GetComponent<Toggle>().isOn = enemyData.Loop;
        
        for (int i = 0; i < enemyData.Pos.Count; i++) {
            addPos.GetComponent<AddMoveListItem>().AddItem(enemyData.Pos[i]);
        }
        ClickBan.SetActive(true);
        GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable = false;
    }
    public void closeEnemyOption() {
        enemyData.SpawnTime = float.Parse(summonTime.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        if (enemyData.SpawnTime < 0) enemyData.SpawnTime = 0;
        else if (enemyData.SpawnTime > 3600) enemyData.SpawnTime = 3600;
        slider.GetComponent<TimeSelect>().MaxSummonTime(enemyData.SpawnTime);
        enemyData.EnemySpeed = float.Parse(movespeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Firerate = float.Parse(firerate.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Bullettype = bullettype.transform.Find("Dropdown").gameObject.GetComponent<Dropdown>().value;
        enemyData.BulletSpeed = float.Parse(bulletspeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.SpreadPoint = int.Parse(spreadpoint.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Hp= int.Parse(hp.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Score = int.Parse(enemyScore.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.SpreadAngle = float.Parse(spreadAngle.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.MaintainTime = float.Parse(maintainTime.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.BulletSize = float.Parse(bulletSize.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        if (enemyData.BulletSize <= 0) enemyData.BulletSize = 1;
        enemyData.Loop=loop.transform.Find("Toggle").gameObject.GetComponent<Toggle>().isOn;
        List<Vector2> posList = new List<Vector2>();
        
            for(int i = 0; i < pos.transform.childCount; i++) {
                Vector2 vector2 = new Vector2();
                
                try {
                    vector2 = new Vector2(float.Parse(pos.transform.GetChild(i).transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text), float.Parse(pos.transform.GetChild(i).transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text));
                } catch {
                    continue;
                }
                posList.Add(vector2);
            }
        if (posList.Count == 0) posList.Add(new Vector2(0f, 0f));
        
        
        enemyData.Pos = posList;
        if (enemyData.SpreadPoint > 30) enemyData.SpreadPoint = 30;
        if (enemyData.Hp <= 0) enemyData.Hp = 1;
        enemy.gameObject.transform.position = enemyData.Pos[0];
        for(int i = 0; i < pos.transform.childCount; i++) {
            Destroy(pos.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < this.transform.childCount; i++) {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
        ClickBan.SetActive(false);
        GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable = true;
        Enemy.GetComponent<ShowEnemyByTime>().show((int)slider.value);
        EnemyListWindow.GetComponent<ShowEnemyList>().show();
        this.gameObject.SetActive(false);
    }
    public void deleteEnemy() {
        GameObject enemys;
        float enemyTime = 0f;
        enemyTime = enemy.GetComponent<EnemyData>().SpawnTime;
        enemys = GameObject.Find("Enemy");
        TimeSelect timeSelect = slider.GetComponent<TimeSelect>();
        int value = timeSelect.GetValue();
        ClickBan.SetActive(false);
        GameObject.Find("Canvas").GetComponent<MyUIHoverListener>().ClickAvailable = true;
        /*timeSelect.resetValue();
        for (int i = 0; i < enemys.transform.childCount; i++) {
            float t = enemys.transform.GetChild(i).GetComponent<EnemyData>().SpawnTime;
            if (enemyTime==t) {
                enemyTime = -1;
                continue;
            }
            timeSelect.MaxSummonTime(t);

        }*/
        //timeSelect.ChangeValue(value);
        for (int i = 0; i < pos.transform.childCount; i++) {
            Destroy(pos.transform.GetChild(i).gameObject);
        }
        Destroy(enemy);
        Enemy.GetComponent<ShowEnemyByTime>().show((int)slider.value);
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
        enemyData.EnemySpeed = float.Parse(movespeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Firerate = float.Parse(firerate.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Bullettype = bullettype.transform.Find("Dropdown").gameObject.GetComponent<Dropdown>().value;
        enemyData.BulletSpeed = float.Parse(bulletspeed.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.SpreadPoint = int.Parse(spreadpoint.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Hp = int.Parse(hp.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.SpreadAngle = float.Parse(spreadAngle.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.Score = int.Parse(enemyScore.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.MaintainTime = float.Parse(maintainTime.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        enemyData.BulletSize = float.Parse(bulletSize.transform.Find("InputField").gameObject.GetComponent<InputField>().text);
        if (enemyData.BulletSize <= 0) enemyData.BulletSize = 1;
        enemyData.Loop = loop.transform.Find("Toggle").gameObject.GetComponent<Toggle>().isOn;
        List<Vector2> posList = new List<Vector2>();

        for (int i = 0; i < pos.transform.childCount; i++) {
            Vector2 vector2 = new Vector2();

            try {
                vector2 = new Vector2(float.Parse(pos.transform.GetChild(i).transform.Find("InputFieldx").gameObject.GetComponent<InputField>().text), float.Parse(pos.transform.GetChild(i).transform.Find("InputFieldy").gameObject.GetComponent<InputField>().text));
            } catch {
                continue;
            }
            posList.Add(vector2);
        }
        if (posList.Count == 0) posList.Add(new Vector2(0f, 0f));


        enemyData.Pos = posList;
        if (enemyData.Hp <= 0) enemyData.Hp = 1;
        newObject.gameObject.transform.position = enemyData.Pos[0];
        Enemy.GetComponent<ShowEnemyByTime>().show((int)slider.value);
    }
}
