using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    public int roundNumber = 1;
    public int EnemyCount, MaxEnemyCount;

    public bool BossAlive, BossKilled;


    public BossController Boss;
    public Text enemyCount, RoundNumber;
    public AI_spawner Spawner;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MaxEnemyCount = roundNumber * 10;
        enemyCount.text = "Enemies Left:" + EnemyCount.ToString();
        RoundNumber.text = "Round: " + roundNumber.ToString();
        if(EnemyCount <= 0 && BossKilled == true)
        {
            BossKilled = false;
            BossAlive = false;
            Boss.BossDead();
            roundNumber++;
            Spawner.roundNumber = roundNumber;
            Spawner.spawnEnemies = true;
            MaxEnemyCount = roundNumber * 3;

            EnemyCount = MaxEnemyCount - 1;
            BossKilled = false;
        }
        else if(EnemyCount <= 0 && BossAlive == false && BossKilled == false)
        {
            BossAlive = true;
            Boss.respawn(roundNumber);
        }


	}
}
