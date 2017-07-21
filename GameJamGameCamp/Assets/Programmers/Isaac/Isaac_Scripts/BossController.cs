using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour {
    public float spd;
    private GameObject player;
    private GameObject aim;
    private float a;
    private Vector3 aimPos;
    public DefaultWeaponController CurrentWeapon;
    private NavMeshAgent boss;
    private Transform point;
    public int lvl, maxLevel = 30;
    public bool IsAlive;
    private Boss_Health_Component bossHP;
    public MeshRenderer mymesh;
    // Use this for initialization
    void Start()
    {
        boss = GetComponent<NavMeshAgent>();
        point = GameObject.FindGameObjectWithTag("Destination").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        spd = 1.5f;
        aim = transform.Find("BossAim").gameObject;
        aimPos = aim.transform.position;
        bossHP = GetComponent<Boss_Health_Component>();
}

    public void BossDead()
    {
        mymesh.enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        IsAlive = false;

    }

    public void BossSpawn()
    {
        IsAlive = true;
        transform.position = new Vector3(0, 1, 0);
        mymesh.enabled = true;
        GetComponent<BoxCollider>().enabled = true;

    }
    public void ResetHealth()
    {
        if (lvl >= 30)
        {
            bossHP.setHealth((float)100 + ((lvl - 30) * 50));
        }
        else
        {
            bossHP.setHealth((float)100);
        }
    }
    public void respawn(int Level)
    {
        BossSpawn();
        lvl = Level;
        ResetHealth();
       
    }
    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {
        float DT = Time.deltaTime;
        if (IsAlive)
        {
            //tiransform.Rotate(transform.forward * spd * Random.Range((float)0, (float)5));
            if (lvl < maxLevel)
            {
                aim.transform.position = new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(a) * (lvl + 1), (float).75 + transform.position.y, (transform.position.z - aimPos.z) + aimPos.z);
                a += Time.deltaTime * 2;
                CurrentWeapon.Fire(DT, true);
                if (Random.Range(0, 50 - lvl) == 0)
                {
                    for (float xOff = -100; xOff < 100; xOff++)
                    {

                        aim.transform.position = new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(xOff) * (lvl / 2 + 1), (float).75 + transform.position.y, (transform.position.z - aimPos.z) + aimPos.z + Mathf.Cos(xOff) * (lvl / 2 + 1));
                        
                        point.position = new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(xOff) * (lvl / 2 + 1), aimPos.y, (transform.position.z - aimPos.z) + aimPos.z + Mathf.Cos(xOff) * (lvl / 2 + 1));
                        CurrentWeapon.Fire(DT, true);

                    }

                }
                if (Random.Range(0, 100 - lvl) == 0)
                {
                    for (float xOff = -100; xOff < 100; xOff += (float).5)
                    {

                        aim.transform.position = new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(xOff) * 1, (float).75 + transform.position.y, (transform.position.z - aimPos.z) + aimPos.z + Mathf.Cos(xOff) * 1);
                        aim.transform.LookAt(new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(xOff) * (float)1.1, (float).75 + transform.position.y, (transform.position.z - aimPos.z) + aimPos.z + Mathf.Cos(xOff) * (float)1.1));
                        CurrentWeapon.Fire(DT, true);

                    }
                }
            }
            else
            {
                aim.transform.position = new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(a) * (maxLevel + 1), (float).75 + transform.position.y, (transform.position.z - aimPos.z) + aimPos.z);
                a += Time.deltaTime * 2;
                CurrentWeapon.Fire(DT, true);
                if (Random.Range(0, 50 - maxLevel) == 0)
                {
                    for (float xOff = -100; xOff < 100; xOff++)
                    {

                        aim.transform.position = new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(xOff) * (maxLevel / 2 + 1), (float).75 + transform.position.y, (transform.position.z - aimPos.z) + aimPos.z + Mathf.Cos(xOff) * (maxLevel / 2 + 1));
                        point.position = new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(xOff) * (lvl / 2 + 1), aimPos.y, (transform.position.z - aimPos.z) + aimPos.z + Mathf.Cos(xOff) * (maxLevel / 2 + 1));
                        CurrentWeapon.Fire(DT, true);

                    }

                }
                if (Random.Range(0, 100 - maxLevel) == 0)
                {
                    for (float xOff = -100; xOff < 100; xOff += (float).5)
                    {

                        aim.transform.position = new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(xOff) * 1, (float).75 + transform.position.y, (transform.position.z - aimPos.z) + aimPos.z + Mathf.Cos(xOff) * 1);
                        aim.transform.LookAt(new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(xOff) * (float)1.1, (float).75 + transform.position.y, (transform.position.z - aimPos.z) + aimPos.z + Mathf.Cos(xOff) * (float)1.1));
                        CurrentWeapon.Fire(DT, true);

                    }
                }
            }

            aim.transform.position = new Vector3(transform.position.x, (float).75 + transform.position.y, transform.position.z);
            aim.transform.LookAt(player.transform);
            //point.position = new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(xOff) * 5, aimPos.y, (transform.position.z - aimPos.z) + aimPos.z + Mathf.Cos(xOff) * 5);

            CurrentWeapon.Fire((float).1, true);


            aim.transform.position = new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(a) * 1, (float).75 + transform.position.y, (transform.position.z - aimPos.z) + aimPos.z + Mathf.Cos(a) * 1);
            aim.transform.LookAt(new Vector3((transform.position.x - aimPos.x) + aimPos.x + Mathf.Sin(a) * (float) 1.1, (float).75 + transform.position.y, (transform.position.z - aimPos.z) + aimPos.z + Mathf.Cos(a) * (float) 1.1));
            CurrentWeapon.Fire((float).1, true);
            if (Random.Range(0, 10) != 0)
            {
                point.position = new Vector3(transform.position.x + (Random.Range(-5, 5) * 10), aimPos.y, transform.position.z + (Random.Range(-5, 5) * 10));
            }

            boss.stoppingDistance = 5;
            transform.LookAt(player.transform);
            boss.SetDestination(point.position);
        }

    }

}

