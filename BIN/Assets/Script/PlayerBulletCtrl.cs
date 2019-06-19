using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCtrl : MonoBehaviour {

    public float bulletSpeed = 1f;
    private int flag = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        /*if (other.gameObject.tag.Equals("playerBullet")){
            gameManager.instance.AddScore(500);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }else */
            if (flag==0&&other.gameObject.tag.Equals("Enemy")&&other.GetComponent<EnemyCtrl>().spawnflag==1) {
            flag++;
            gameManager.instance.AddScore(500);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
        }

    }
}
