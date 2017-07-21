using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI_Melee_Controller : MonoBehaviour {

    public GameObject HitBox;
    public float MinRange, MaxRange;
    public float SetAcceleration, SetSpeed, BaseAcceleration, BaseSpeed;
    private GameObject Target;
    private NavMeshAgent Agent;
    public Animator anime;


	// Use this for initialization
	void Start () {
        SetAcceleration = BaseAcceleration;
        SetSpeed = BaseSpeed;
        Agent = GetComponent<NavMeshAgent>();

        Target = GameObject.FindGameObjectWithTag("Player");
        Agent.SetDestination(Target.transform.position);

    }
    bool isBiting;

  
    float DT;
    public float AttackCooldown, SetAttackCooldown;
    // Update is called once per frame
    void Update () {

        DT = Time.deltaTime;
        SetAttackCooldown -= DT;

        Agent.SetDestination(Target.transform.position);

        if (Agent.remainingDistance < MinRange)
        {
            Agent.isStopped = true;
            if (!isBiting && SetAttackCooldown <= 0)
            {
                anime.SetTrigger("Attack");
            }
        }
        else
        {
            
        }


        if(Agent.isStopped == false)
        {
            anime.SetFloat("Speed", 1);
        }
        else
        {
            anime.SetFloat("Speed", 0);
        }
	}
    public void RatBite()
    {
        isBiting = true;
        HitBox.SetActive(true);
    }
    public void StopRatBite()
    {
        SetAttackCooldown = AttackCooldown;
        isBiting = false;
        HitBox.SetActive(false);
    }

}
