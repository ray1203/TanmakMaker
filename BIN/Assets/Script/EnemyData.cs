using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData :MonoBehaviour {
    private float spawnTime = 2f;//0
    private float enemySpeed = 2.0f;//1
    private int bullettype;//0:normal 1:following//2
    private float firerate = 0f;//3
    private float bulletSpeed = 0f;//4
    private float bulletSize = 0f;//5
    private int spreadPoint;//6
    private int hp = 1;//7
    private float maintainTime = 1;//8
    private float spreadAngle;//9
    private int score;//10
    private bool loop;//11
    private List<Vector2> pos;//12~
    private Sprite enemySprite;

    /*VERSION0
     * public EnemyData(float spawnTime, float enemySpeed, int bullettype, float firerate, float bulletSpeed, int spreadPoint, int hp, Sprite enemySprite, List<Vector2> pos, float spreadAngle, int score) {
        this.spawnTime = spawnTime;
        this.enemySpeed = enemySpeed;
        this.bullettype = bullettype;
        this.firerate = firerate;
        this.bulletSpeed = bulletSpeed;
        this.spreadPoint = spreadPoint;
        this.hp = hp;
        this.enemySprite = enemySprite;
        this.pos = pos;
        this.spreadAngle = spreadAngle;
        this.score = score;
    }*/

    public EnemyData(float spawnTime, float enemySpeed, int bullettype, float firerate, float bulletSpeed, float bulletSize, int spreadPoint, int hp, float maintainTime, float spreadAngle, int score, bool loop, List<Vector2> pos, Sprite enemySprite) {
        this.spawnTime = spawnTime;
        this.enemySpeed = enemySpeed;
        this.bullettype = bullettype;
        this.firerate = firerate;
        this.bulletSpeed = bulletSpeed;
        this.bulletSize = bulletSize;
        this.spreadPoint = spreadPoint;
        this.hp = hp;
        this.maintainTime = maintainTime;
        this.spreadAngle = spreadAngle;
        this.score = score;
        this.loop = loop;
        this.pos = pos;
        this.enemySprite = enemySprite;
    }

    public void putDatas(EnemyData e) {
        this.spawnTime = e.spawnTime;
        this.enemySpeed = e.enemySpeed;
        this.bullettype = e.bullettype;
        this.firerate = e.firerate;
        this.bulletSpeed = e.bulletSpeed;
        this.spreadPoint = e.spreadPoint;
        this.hp = e.hp;
        this.enemySprite = e.enemySprite;
        this.pos = e.pos;
        this.spreadAngle = e.spreadAngle;
        this.score = e.score;
        this.loop = e.loop;
        this.maintainTime = e.maintainTime;
        this.bulletSize = e.bulletSize;
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

    public int Bullettype {
        get {
            return bullettype;
        }

        set {
            bullettype = value;
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

    public int SpreadPoint {
        get {
            return spreadPoint;
        }

        set {
            spreadPoint = value;
        }
    }

    public int Hp {
        get {
            return hp;
        }

        set {
            hp = value;
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

    public List<Vector2> Pos {
        get {
            return pos;
        }

        set {
            pos = value;
        }
    }

    public float SpreadAngle {
        get {
            return spreadAngle;
        }

        set {
            spreadAngle = value;
        }
    }

    public int Score {
        get {
            return score;
        }

        set {
            score = value;
        }
    }

    public float BulletSize {
        get {
            return bulletSize;
        }

        set {
            bulletSize = value;
        }
    }

    public bool Loop {
        get {
            return loop;
        }

        set {
            loop = value;
        }
    }

    public float MaintainTime {
        get {
            return maintainTime;
        }

        set {
            maintainTime = value;
        }
    }


}
