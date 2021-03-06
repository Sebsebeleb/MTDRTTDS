﻿using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MinionManager : MonoBehaviour {

    private List<EnemyMove> enemyList = new List<EnemyMove>(); 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

    public void OnPathRecalculate()
    {
        foreach (EnemyMove minion in enemyList) {
            minion.RecalculatePath();
        }
    }

    public void SpawnMinion(GameObject minion, Vector3 spawnPos)
    {
        GameObject newMinion = Instantiate(minion, spawnPos, Quaternion.identity) as GameObject;
        enemyList.Add(newMinion.GetComponent<EnemyMove>());
    }
}
