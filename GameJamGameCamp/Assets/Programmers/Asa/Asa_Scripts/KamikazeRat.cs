using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KamikazeRat : MonoBehaviour {

    private NavMeshAgent Agent;
    private GameObject DesiredPoint;
    public float BaseMoveSpeed = 10, BaseAccelerationRate = 10;
    private float SetMoveSpeed, SetAccelerationRate;
    public ParticleSystem PS;
    public float ExplosionRadius;
    public float ExplosionDamage;

    // Use this for initialization
    void Start () {

        Agent = GetComponent<NavMeshAgent>();
        DesiredPoint = GameObject.FindGameObjectWithTag("Player");
        SetMoveSpeed = BaseMoveSpeed;
        SetAccelerationRate = BaseAccelerationRate;
        Agent.SetDestination(DesiredPoint.transform.position);

    }

    void Explode(string Target)
    {

        ParticleSystem temp = Instantiate(PS, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(temp, 1.0f);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, ExplosionRadius);

        for (int i = 0; i < hitColliders.Length; i++) { 

            if (hitColliders[i].GetComponent<Health_Component>() != null && hitColliders[i].CompareTag(Target))
            {

                hitColliders[i].GetComponent<Health_Component>().AddDamage(ExplosionDamage);

            }

        }

        Destroy(gameObject);

    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            
            Explode("Player");

        }

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Agent.SetDestination(DesiredPoint.transform.position);

        SetMoveSpeed = BaseMoveSpeed;
        SetAccelerationRate = BaseAccelerationRate;

        Agent.speed = SetMoveSpeed;
        Agent.acceleration = SetAccelerationRate;
                      
    }
}
