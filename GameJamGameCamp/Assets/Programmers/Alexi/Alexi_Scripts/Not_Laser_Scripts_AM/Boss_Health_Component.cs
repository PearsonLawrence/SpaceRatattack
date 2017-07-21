using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health_Component : MonoBehaviour {
    public int StartHealth = 5;
    public float CurrentHealth;

    public BossController bossy;
    public GameManager Game;
    // Use this for initialization
    void Start()
    {
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
    void Update()
    {

        if (CurrentHealth <= 0 && Game.BossKilled == false)
        {
            Game.BossKilled = true;
            bossy.BossDead();
            bossy.ResetHealth();
            
        }

    }
}
