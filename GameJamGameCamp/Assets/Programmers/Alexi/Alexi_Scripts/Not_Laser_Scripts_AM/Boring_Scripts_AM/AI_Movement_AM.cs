using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement_AM1 : MonoBehaviour
{

    private NavMeshAgent Agent;
    private Transform DesiredPoint;
    public float BaseMoveSpeed = 5, BaseAccelerationSpeed = 10;
    private float SetMoveSpeed, SetAccelerationSpeed;
    // Use this for initialization
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        DesiredPoint = GameObject.FindGameObjectWithTag("DesiredPoint").transform;
        SetMoveSpeed = BaseMoveSpeed;
        SetAccelerationSpeed = BaseAccelerationSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        Agent.SetDestination(DesiredPoint.position);

        SetMoveSpeed = BaseMoveSpeed;
        SetAccelerationSpeed = BaseAccelerationSpeed;

        Agent.speed = SetMoveSpeed;
        Agent.acceleration = SetAccelerationSpeed;

    }

}
