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
                E.GetComponent<EnemyCtrl>().spawnPoint = e.transform.GetChild(i).GetComponent<EnemyData>().SpawnPoint;
                E.GetComponent<EnemyCtrl>().pos1 = e.transform.GetChild(i).GetComponent<EnemyData>().Pos1;
                E.GetComponent<EnemyCtrl>().pos2 = e.transform.GetChild(i).GetComponent<EnemyData>().Pos2;
                E.GetComponent<EnemyCtrl>().spawnTime = e.transform.GetChild(i).GetComponent<EnemyData>().SpawnTime;
                E.GetComponent<EnemyCtrl>().enemySpeed = e.transform.GetChild(i).GetComponent<EnemyData>().EnemySpeed;
                E.GetComponent<EnemyCtrl>().firerate = e.transform.GetChild(i).GetComponent<EnemyData>().Firerate;
                E.GetComponent<EnemyCtrl>().bulletSpeed = e.transform.GetChild(i).GetComponent<EnemyData>().BulletSpeed;
                E.GetComponent<EnemyCtrl>().spreadPoint = e.transform.GetChild(i).GetComponent<EnemyData>().SpreadPoint;
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
            Time.timeScale = 0.0f;
        }
	}
}
