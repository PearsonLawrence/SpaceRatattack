using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement_copy_NZ : MonoBehaviour
{

    private NavMeshAgent Agent;
    private GameObject DesiredPoint;
    public float BaseMoveSpeed = 5, BaseAccelerationSpeed = 10;
    private float SetMoveSpeed, SetAccelerationSpeed;
    private float DT;

    public float MaxAIRange, MinAIRange;

    public float AIWanderRadius = 10, AIWanderTimer = 5;
    private float AITimer;

    public AI_WeaponController_NZ AICurrentWeapon;
    private GameObject AICurrentWeaponGameObject;
    //private bool AIFireNow;


    // Use this for initialization
    void Start()
    {
        AITimer = AIWanderTimer;
        AICurrentWeaponGameObject = AICurrentWeapon.gameObject;
        Agent = GetComponent<NavMeshAgent>();
        DesiredPoint = GameObject.FindGameObjectWithTag("Player");
        SetMoveSpeed = BaseMoveSpeed;
        SetAccelerationSpeed = BaseAccelerationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        DT = Time.deltaTime;

        //Code for random wandering
        //AITimer += DT;

        /*if (AITimer >= AIWanderTimer)
		{
			
			Agent.SetDestination();
			/*Vector3 newPos = Random.insideUnitSphere (transform.position, AIWanderRadius, -1);
			Agent.SetDestination (newPos);
			AITimer = 0;
		}*/

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

            RaycastHit hit;
            if (Physics.Linecast(transform.position, DesiredPoint.transform.position, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {

                    if (Vector3.Distance(transform.position, DesiredPoint.transform.position) <= MinAIRange)
                    {
                        AICurrentWeaponGameObject.GetComponent<AI_WeaponController_NZ>().AIFireActive = true;
                    }

                }
                else
                {
                       AICurrentWeaponGameObject.GetComponent<AI_WeaponController_NZ>().AIFireActive = false;
                }

            }
            /* if (Physics.Linecast(transform.position, DesiredPoint.position, 1 << 1))
             {
                 Debug.DrawLine(transform.position, DesiredPoint.position);
                 Debug.Log("blocked");
             }*/


            //Code for AI Gun
            //Find a way to make AI fire when within a certain range
            //AICurrentWeapon.Fire(DT, AIFireActive);

        }
    }
}

//if ((Vector3.Distance (transform.position, DesiredPoint.position) < MaxAIRange) && (Vector3.Distance(transform.position, DesiredPoint.position))
//(Vector3.Distance(transform.position, DesiredPoint.position) > MinAIRange))