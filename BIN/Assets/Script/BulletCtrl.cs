using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {
    public float bulletSpeed = 1f;
    public bool normalBullet = true;
    public bool playeFollowingBullet = false;
    
    Vector3 playerPos;
	// Use this for initialization
	void Start () {
        playerPos = GameObject.Find("player").GetComponent<PlayerCtrl>().pos();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (normalBullet){
            transform.Translate(0, -bulletSpeed * Time.deltaTime, 0);
        }
        else if (playeFollowingBullet)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, bulletSpeed * Time.deltaTime);
           
        }

        
	}
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
