using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData :MonoBehaviour {
    private Vector2 spawnPoint = new Vector2(0, 0);
    private Vector2 pos1=new Vector2(0,0);
    private Vector2 pos2 = new Vector2(0, 0);
    private float spawnTime = 2f;
    private float enemySpeed = 2.0f;
    private Sprite bulletSprite;
    private int bullettype;//0:normal 1:following
    private float firerate = 0f;
    private float bulletSpeed = 0f;
    private Sprite enemySprite;
    private Color color;
    private int spreadPoint;

    public EnemyData(Vector2 spawnPoint, Vector2 pos1, Vector2 pos2, float spawnTime, float enemySpeed,  int bullettype, float firerate, float bulletSpeed,  Color color,Sprite bulletSprite,Sprite enemySprite, int spreadPoint) {
        this.spawnPoint = spawnPoint;
        this.pos1 = pos1;
        this.pos2 = pos2;
        this.spawnTime = spawnTime;
        this.enemySpeed = enemySpeed;
        this.bulletSprite = bulletSprite;
        this.bullettype = bullettype;
        this.firerate = firerate;
        this.bulletSpeed = bulletSpeed;
        this.enemySprite = enemySprite;
        this.color = color;
        this.spreadPoint = spreadPoint;
    }
    public void putDatas(EnemyData e) {
        this.spawnPoint = e.spawnPoint;
        this.pos1 = e.pos1;
        this.pos2 = e.pos2;
        this.spawnTime = e.spawnTime;
        this.enemySpeed = e.enemySpeed;
        this.bulletSprite = e.bulletSprite;
        this.bullettype = e.bullettype;
        this.firerate = e.firerate;
        this.bulletSpeed = e.bulletSpeed;
        this.enemySprite = e.enemySprite;
        this.color = e.color;
        this.spreadPoint = e.spreadPoint;
    }
    public void printDatas() {
        Debug.Log("spawnpoint:" + spawnPoint + ",pos1:" + pos1 + ",pos2:" + pos2 + ",spawntime:" + spawnTime + ",enemyspeed:" + enemySpeed);
    }
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

    public Sprite BulletSprite {
        get {
            return bulletSprite;
        }

        set {
            bulletSprite = value;
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

    public int Bullettype {
        get {
            return bullettype;
        }

        set {
            bullettype = value;
        }
    }
    public Sprite EnemySprite {
        get {
            return enemySprite;
        }

        set {
            enemySprite = value;
        }
    }

    public Color Color {
        get {
            return color;
        }

        set {
            color = value;
        }
    }
    public int SpreadPoint {
        get {
            return spreadPoint;
        }

        set {
            spreadPoint = value;
        }
    }
}
