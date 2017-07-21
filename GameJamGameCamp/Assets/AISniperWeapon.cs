﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISniperWeapon : MonoBehaviour {

    public float FireRate = .5f, SetFireRate;
    public float BulletSpeed, SetBulletSpeed;
    public float DestroyTime = 3;
    public GameObject Bullet;

    public string DesiredSpecialWeapon;
    public string CurrentSepcialWeapon;

    public Transform FirePoint;



    private void Start()
    {
        CurrentSepcialWeapon = DesiredSpecialWeapon;
        SetFireRate = 0;
        SetBulletSpeed = BulletSpeed;
    }

    public void SpawnBullet()
    {
        SetBulletSpeed = BulletSpeed;
        SetFireRate = FireRate;
        GameObject TempBullet = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        TempBullet.GetComponent<Rigidbody>().velocity = TempBullet.transform.forward * SetBulletSpeed;
        Destroy(TempBullet, DestroyTime);
    }

    public void Fire(float DT)
    {
        SetFireRate -= DT;

        if (SetFireRate <= 0)
        {
            SpawnBullet();
        }

    }
    public Sniper_Movement snip;
    void Update()
    {


        if (snip.CanFire == true)
        {
            Fire(Time.deltaTime);
            
        }
        

    }
}