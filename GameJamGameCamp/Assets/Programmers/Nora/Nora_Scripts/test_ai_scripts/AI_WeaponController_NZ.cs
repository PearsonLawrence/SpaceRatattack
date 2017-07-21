using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_WeaponController_NZ : MonoBehaviour
{

    public float FireRate = .5f, SetFireRate;
    public float BulletSpeed, SetBulletSpeed;
    public float DestroyTime = 3;
    public GameObject Bullet;
    private float DT;
    public Transform FirePoint;

    public bool AIFireActive;

    private void Start()
    {
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

    public void AIFire()
    {
        SetFireRate -= DT;

        if (SetFireRate <= 0 && AIFireActive)
        {
            SpawnBullet();
        }

    }

    void Update()
    {
        DT = Time.deltaTime;
        AIFire();

    }
}
