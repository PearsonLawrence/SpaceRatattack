using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*need: Player health, enemy health, boss health
 * starting player health = 5
 * player health can't exceed 5
 * enemy health = 1
 * 
 * */
public class Health_Component : MonoBehaviour {

    public int StartHealth = 5;
    public float CurrentHealth;
    public string OurName;
    private GameManager Game;
	// Use this for initialization
	void Start () {
        Game = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        CurrentHealth = StartHealth;
	}
	
    public void AddDamage(float DamageAmount)
    {
        CurrentHealth -= DamageAmount;
    }

    public void AddHealth(float HealthAmount)
    {
        CurrentHealth += HealthAmount;
    }

    public void modifyHealth(float amount)
    {
        CurrentHealth += amount;
    }

    public void setHealth(float amount)
    {
        CurrentHealth = amount;
    }
    
	// Update is called once per frame
	void Update () {

        if (CurrentHealth <= 0)
        {
            if (!CompareTag("Barrel") && !CompareTag("Boss"))
            {
                if (OurName == "Rats")
                {
                    Game.EnemyCount--;
                }
                Destroy(gameObject);
            }
        }

  
        
       
	}
}
