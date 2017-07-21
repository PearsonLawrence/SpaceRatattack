using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcallShotgun : MonoBehaviour
{

    public float FireRate = .5f, SetFireRate;
    public float BulletSpeed, SetBulletSpeed;
    public float DestroyTime = 3;
    public GameObject Bullet;

    public Transform FirePoint, FirePoint2, FirePoint3;

    float DT;
    private void Start()
    {
        SetFireRate = 2;
        SetBulletSpeed = BulletSpeed;
    }

    private void Update()
    {

        DT = Time.deltaTime;
        SetFireRate -= DT;

        if (Input.GetMouseButtonDown(1))
        {
            Fire(DT, true);
        }
    }

    public void SpawnBullet()
    {
        SetBulletSpeed = BulletSpeed;
        SetFireRate = FireRate;
        GameObject TempBullet = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        TempBullet.GetComponent<Rigidbody>().velocity = TempBullet.transform.forward * SetBulletSpeed;
        Destroy(TempBullet, DestroyTime);
        GameObject TempBullet2 = Instantiate(Bullet, FirePoint2.position, FirePoint2.rotation);
        TempBullet2.GetComponent<Rigidbody>().velocity = TempBullet2.transform.forward * SetBulletSpeed;
        Destroy(TempBullet2, DestroyTime);
        GameObject TempBullet3 = Instantiate(Bullet, FirePoint3.position, FirePoint3.rotation);
        TempBullet3.GetComponent<Rigidbody>().velocity = TempBullet3.transform.forward * SetBulletSpeed;
        Destroy(TempBullet3, DestroyTime);
    }

    public void Fire(float DT1, bool IsFiring)
    {
        SetFireRate -= DT1;

        if (SetFireRate <= 0 && IsFiring)
        {
            SpawnBullet();
        }

    }
}

