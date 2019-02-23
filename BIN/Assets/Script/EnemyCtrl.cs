using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour {
    public Vector2 spawnPoint;
    public Vector2 pos1;
    public Vector2 pos2;
    private int flag = 0;//pos1 도착 시 1 pos2 도착 시 2
    private int spawnflag = 0;
    public float spawnTime = 2f;
    public float enemySpeed = 2.0f;
    private Vector2 pos;
    public GameObject bullet;
    public float firerate = 0.5f;
    private float rate = 0f;
    public float bulletSpeed=10.0f;
	void Start () {
        
	}
	
	void Update () {
        if (GameObject.Find("player")) {
            if (spawnflag == 0 && GameObject.Find("player").GetComponent<PlayerCtrl>().aliveTime >= spawnTime) {
                gameObject.transform.position = spawnPoint;
                spawnflag = 1;
            }
        }
        pos = gameObject.transform.position;
        if (spawnflag == 1)
        {
            move();
            fire();
        }
        
	}
    private void move()
    {
        
        if (flag == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos1, enemySpeed * Time.deltaTime);
            pos = gameObject.transform.position;

            if (pos1 == pos) flag = 1;
        }
        else if (flag == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos2, enemySpeed * Time.deltaTime);
            pos = gameObject.transform.position;

            if (pos2 == pos) flag = 2;
        }
        else if (flag == 2)
        {
            transform.Translate(0, enemySpeed * Time.deltaTime, 0);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void fire()
    {
        rate += Time.deltaTime;
        if (rate >= firerate)
        {
            bullet.GetComponent<BulletCtrl>().giveSpeed(bulletSpeed);
            Instantiate(bullet,transform.position,Quaternion.identity);
            rate = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("playerBullet"))
        {
            gameManager.instance.AddScore(500);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
