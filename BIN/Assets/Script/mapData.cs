﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapData : MonoBehaviour
{
    private List<EnemyData> enemyDatas = new List<EnemyData>();

    public List<EnemyData> EnemyDatas {
        get {
            return enemyDatas;
        }

        set {
            enemyDatas = value;
        }
    }
}