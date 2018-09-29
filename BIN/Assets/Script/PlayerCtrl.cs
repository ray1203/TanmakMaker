using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    public float playerSpeed = 10f;
    public float aliveTime = 0f;
    public GameObject bullet;
    public float rate = 0f;
    public float firerate = 0.5f;
	void Start () {
		
	}
	
	void Update () {
        move();
        stop();
        fire();
        
        aliveTime += Time.deltaTime;
        
        
	}

    private void move()
    {
        float inputx, inputy;
        inputx = Input.GetAxisRaw("Horizontal") * Time.deltaTime * playerSpeed;
        inputy = Input.GetAxisRaw("Vertical") * Time.deltaTime * playerSpeed;
        
        this.gameObject.transform.Translate(inputx, inputy, 0);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy")||other.gameObject.tag.Equals("enemyBullet"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
    private void fire()
    {
        rate += Time.deltaTime;
        if (rate >= firerate)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            rate = 0;
        }
    }
    public void stop()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }
}
