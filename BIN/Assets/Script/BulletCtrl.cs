using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {
    public float bulletSpeed = 1f;
    public bool normalBullet = true;
    public bool playerFollowingBullet = false;
    public bool spreadBullet = false;
    public float spreadAngle = 0;
    private int t = 0;
    Vector3 followPos;
    Vector3 playerPos;
	// Use this for initialization
	void Start () {
        if (spreadBullet) {
            spreadAngle = spreadAngle * Mathf.PI / 180;
            followPos.x = transform.position.x + Mathf.Sin(spreadAngle) * 100;
            followPos.y= transform.position.y + Mathf.Cos(spreadAngle) * 100;
        } else if (GameObject.Find("player") == true)
        {
            playerPos = GameObject.Find("player").GetComponent<PlayerCtrl>().pos();
            followPos.x = playerPos.x+((this.gameObject.transform.position.x-playerPos.x)*100);
            followPos.y = playerPos.y + ((this.gameObject.transform.position.y-playerPos.y )*100);
            
        }
        else
        {
            normalBullet = true;
            playerFollowingBullet = false;
            spreadBullet = false;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if (bulletSpeed == 0f) {
            t++;
            if (t > 20) Destroy(this.gameObject);
        }
        if (normalBullet){
            transform.Translate(0, -bulletSpeed * Time.deltaTime, 0);
        }
        else if (playerFollowingBullet||spreadBullet)
        {
            transform.position = Vector3.MoveTowards(transform.position, followPos, bulletSpeed * Time.deltaTime);
           
        }

        
	}
    public void giveSpeed(float sp)
    {
        bulletSpeed = sp;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
