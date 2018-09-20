using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {
    public float bulletSpeed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -bulletSpeed*Time.deltaTime, 0);
	}
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
