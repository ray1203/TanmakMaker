using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {
    public static gameManager instance;
    public Text scoreText;
    private int score = 0;
    public GameObject EnemyBase;
    public Sprite sprite;
    private GameObject e;
    public GameObject victory;
    void Start()
    {
        if (GameObject.FindWithTag("fill")) {
            e = GameObject.FindWithTag("fill").gameObject;
            for (int i = 0; i < e.transform.childCount; i++) {
                GameObject E = EnemyBase;
                EnemyCtrl enemyCtrl = E.GetComponent<EnemyCtrl>();
                EnemyData enemyData = e.transform.GetChild(i).GetComponent<EnemyData>();
                enemyCtrl.posList =     enemyData.Pos;
                enemyCtrl.spawnTime =   enemyData.SpawnTime;
                enemyCtrl.enemySpeed =  enemyData.EnemySpeed;
                enemyCtrl.firerate =    enemyData.Firerate;
                enemyCtrl.bulletSpeed = enemyData.BulletSpeed;
                enemyCtrl.spreadPoint = enemyData.SpreadPoint;
                enemyCtrl.hp =          enemyData.Hp;
                enemyCtrl.enemyScore =  enemyData.Score;
                enemyCtrl.spreadAngle = enemyData.SpreadAngle;
                enemyCtrl.loop =        enemyData.Loop;
                enemyCtrl.bulletSize =  enemyData.BulletSize;
                enemyCtrl.maintainTime= enemyData.MaintainTime;
                if (enemyCtrl.maintainTime <= 0) enemyCtrl.maintainTime = 3600f;
                E.GetComponent<SpriteRenderer>().sprite = sprite;
                E.transform.localScale = new Vector2(1.0f, 1.0f);
                //E.GetComponent<SpriteRenderer>().color = e.transform.GetChild(i).GetComponent<EnemyData>().Color;

                if (e.transform.GetChild(i).GetComponent<EnemyData>().Bullettype == 0) {
                    E.GetComponent<EnemyCtrl>().normalBullet = true;
                    E.GetComponent<EnemyCtrl>().playerFollowingBullet = false;
                    E.GetComponent<EnemyCtrl>().spreadBullet = false;
                } else if(e.transform.GetChild(i).GetComponent<EnemyData>().Bullettype == 1) {
                    E.GetComponent<EnemyCtrl>().playerFollowingBullet = true;
                    E.GetComponent<EnemyCtrl>().normalBullet = false;
                    E.GetComponent<EnemyCtrl>().spreadBullet = false;
                } else if (e.transform.GetChild(i).GetComponent<EnemyData>().Bullettype == 2) {
                    E.GetComponent<EnemyCtrl>().playerFollowingBullet = false;
                    E.GetComponent<EnemyCtrl>().normalBullet = false;
                    E.GetComponent<EnemyCtrl>().spreadBullet = true;
                }
                Instantiate(E);
            }
        }
        if (!instance)
            instance = this;

        Time.timeScale = 1;
    }
    public void AddScore(int num)
    {
        score += num; //점수를 더해줍니다.
        scoreText.text = "Score : " + score;
    }
    private int t = 0;
	
	// Update is called once per frame
	void Update () {
        t++;
        if (t>10&&!GameObject.FindWithTag("Enemy")) {
            victory.SetActive(true);
            try {
                victory.transform.Find("Image").Find("Result").GetComponent<Text>().text = GameObject.FindWithTag("MapName").name + " 맵에서 " + score + "점을 달성하였습니다.";
            }catch {

            }
            
            Time.timeScale = 0.0f;
            
        }
	}
}
