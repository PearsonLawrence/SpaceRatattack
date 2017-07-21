using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gunman_Movement : MonoBehaviour
{

    private NavMeshAgent Agent;
    private GameObject DesiredPoint;
    public float BaseMoveSpeed = 5, BaseAccelerationSpeed = 10;
    private float SetMoveSpeed, SetAccelerationSpeed;
    // Use this for initialization
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        DesiredPoint = GameObject.FindGameObjectWithTag("Player");
        SetMoveSpeed = BaseMoveSpeed;
        SetAccelerationSpeed = BaseAccelerationSpeed;
        Agent.SetDestination(DesiredPoint.transform.position);

    }
    public bool CanFire;
    // Update is called once per frame
    void Update()
    {

        Agent.SetDestination(DesiredPoint.transform.position);

        SetMoveSpeed = BaseMoveSpeed;
        SetAccelerationSpeed = BaseAccelerationSpeed;

        Agent.speed = SetMoveSpeed;
        Agent.acceleration = SetAccelerationSpeed;

        
        if(Agent.remainingDistance <= 15)
        {
            Agent.isStopped = true;
            var temp = -(transform.position - DesiredPoint.transform.position).normalized;
            transform.forward = Vector3.Slerp(transform.forward, temp, .1f);
            transform.forward = new Vector3(transform.forward.x, 0 , transform.forward.z);

                CanFire = true;
            
        }
        else
        {

            Agent.isStopped = false;
            CanFire = false;
        }
    }

}
