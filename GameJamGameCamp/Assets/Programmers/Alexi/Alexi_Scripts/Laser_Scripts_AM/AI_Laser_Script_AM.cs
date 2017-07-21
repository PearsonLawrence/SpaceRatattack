using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Laser_Script_AM : MonoBehaviour
{

    private NavMeshAgent Agent;
    private GameObject DesiredPoint;
    public float BaseMoveSpeed = 5, BaseAccelerationSpeed = 10;
    private float SetMoveSpeed, SetAccelerationSpeed;
    private float DT;

    public float MaxAIRange, MinAIRange;


    float DamageTimer;
    public float SetDamageTimer;
    public float DamageAmount;

    LineRenderer line;
    public ParticleSystem particleSystem;


    // Use this for initialization
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        DesiredPoint = GameObject.FindGameObjectWithTag("Player");
        SetMoveSpeed = BaseMoveSpeed;
        SetAccelerationSpeed = BaseAccelerationSpeed;

        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
        particleSystem.Stop();
        particleSystem.Clear();

    }

    // Update is called once per frame
    void Update()
    {
        DT = Time.deltaTime;
        DamageTimer -= DT;

        //Code for movespeed
        SetMoveSpeed = BaseMoveSpeed;
        SetAccelerationSpeed = BaseAccelerationSpeed;

        Agent.speed = SetMoveSpeed;
        Agent.acceleration = SetAccelerationSpeed;

        //Code for following player
        if ((Vector3.Distance(transform.position, DesiredPoint.transform.position) < MaxAIRange))
        {
            transform.LookAt(DesiredPoint.transform.position);
            Agent.SetDestination(DesiredPoint.transform.position);

        }

       
    }

    IEnumerator FireLaser()
    {
        line.enabled = true;

        while ((Vector3.Distance(transform.position, DesiredPoint.transform.position) < MaxAIRange))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            line.SetPosition(0, ray.origin);

            particleSystem.Play();


            if (Physics.Raycast(ray, out hit, 100))
            {
                line.SetPosition(1, hit.point);
            }
            else
            {
                line.SetPosition(1, ray.GetPoint(100));
            }

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    if (DamageTimer <= 0)
                    {
                        hit.collider.GetComponent<Health_Component>().AddDamage(DamageAmount);
                        DamageTimer = SetDamageTimer;
                    }
                }
            }

            yield return null;
        }
        line.enabled = false;
        particleSystem.Stop();
        particleSystem.Clear();

    }
}


