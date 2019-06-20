using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour {
    public Vector2 spawnPoint;
    public Vector2 pos1;
    public Vector2 pos2;
    private int flag = 0;//pos1 도착 시 1 pos2 도착 시 2
    public int spawnflag = 0;
    public float spawnTime = 2f;
    public float enemySpeed = 2.0f;
    private Vector2 pos;
    public GameObject bullet;
    public float firerate = 0.5f;
    private float rate = 0f;
    public float bulletSpeed=10.0f;
    public bool normalBullet = true;
    public bool playerFollowingBullet = false;
    public bool spreadBullet = false;
    public int spreadPoint = 0;
    public float angle = 0f;
    public float spreadRotateAngle = 0f;
    private Camera subCamera;
    private BulletCtrl bulletCtrl;
	void Start () {
        bulletCtrl = bullet.GetComponent<BulletCtrl>();
        subCamera = GameObject.FindWithTag("SubCamera").GetComponent<Camera>();
        angle = 360f / (float)(spreadPoint);
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
        //Vector2 screenPos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        //if (screenPos.x > 3300 || screenPos.x < 2700 || screenPos.y > 1000 || screenPos.y < 0) {
        //    Destroy(this.gameObject);
       // }
        
        
	}
    private void move()
    {
        
        if (flag == 0)
        {
            transform.position = (Vector3.MoveTowards(transform.position, pos1, enemySpeed * Time.deltaTime));
            pos = gameObject.transform.position;

            if (pos1 == pos) flag = 1;
        }
        else if (flag == 1)
        {
            transform.position = (Vector3.MoveTowards(transform.position, pos2, enemySpeed * Time.deltaTime));
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
        if (rate >= firerate) {
            bulletCtrl.giveSpeed(bulletSpeed);
            bulletCtrl.playerFollowingBullet = this.playerFollowingBullet;
            bulletCtrl.normalBullet = this.normalBullet;
            bulletCtrl.spreadBullet = this.spreadBullet;
            if (spreadBullet) {
                for(int i = 0; i < spreadPoint; i++) {
                    bulletCtrl.spreadAngle = 180f+i * angle+spreadRotateAngle;
                    Instantiate(bullet,transform.position,Quaternion.identity);
                }
                spreadRotateAngle += 10f;
                //spreadRotateAngle += angle / 2;
                if (spreadRotateAngle >= 360f) spreadRotateAngle -= 360f;
            } else {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
            
            rate = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (spawnflag == 1) {
            /*if (other.gameObject.tag.Equals("playerBullet")){
                gameManager.instance.AddScore(500);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }else */if (other.gameObject.tag.Equals("Player")) {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "CameraColider")
            Destroy(this.gameObject);
    }
}
