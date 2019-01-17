using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData:MonoBehaviour {
    private Vector2 spawnPoint;
    private Vector2 pos1;
    private Vector2 pos2;
    private float spawnTime = 2f;
    private float enemySpeed = 2.0f;
    private GameObject bullet;
    private float firerate = 0f;
    private float bulletSpeed = 0f;

    public Vector2 SpawnPoint {
        get {
            return spawnPoint;
        }

        set {
            spawnPoint = value;
        }
    }

    public Vector2 Pos1 {
        get {
            return pos1;
        }

        set {
            pos1 = value;
        }
    }

    public Vector2 Pos2 {
        get {
            return pos2;
        }

        set {
            pos2 = value;
        }
    }

    public float SpawnTime {
        get {
            return spawnTime;
        }

        set {
            spawnTime = value;
        }
    }

    public float EnemySpeed {
        get {
            return enemySpeed;
        }

        set {
            enemySpeed = value;
        }
    }

    public GameObject Bullet {
        get {
            return bullet;
        }

        set {
            bullet = value;
        }
    }

    public float Firerate {
        get {
            return firerate;
        }

        set {
            firerate = value;
        }
    }

    public float BulletSpeed {
        get {
            return bulletSpeed;
        }

        set {
            bulletSpeed = value;
        }
    }
    public void SetEnemyData(Vector2 spawnPoint, Vector2 pos1, Vector2 pos2, float spawnTime, float enemySpeed, GameObject bullet, float firerate, float bulletSpeed) {
        this.SpawnPoint = spawnPoint;
        this.Pos1 = pos1;
        this.Pos2 = pos2;
        this.SpawnTime = spawnTime;
        this.EnemySpeed = enemySpeed;
        this.Bullet = bullet;
        this.Firerate = firerate;
        this.BulletSpeed = bulletSpeed;
    }
}
