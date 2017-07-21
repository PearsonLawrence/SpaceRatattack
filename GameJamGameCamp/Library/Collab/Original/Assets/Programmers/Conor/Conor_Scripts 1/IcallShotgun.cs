using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcallShotgun : MonoBehaviour
{

    public float FireRate = .5f, SetFireRate;
    public float BulletSpeed, SetBulletSpeed;
    public float DestroyTime = 3;
    public GameObject Bullet;

    public Transform[] FirePoints;

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
        
    }

    public void SpawnBullet()
    {
        SetBulletSpeed = BulletSpeed;
        SetFireRate = FireRate;
        for (int i = 0; i < FirePoints.Length; i++)
        {
            GameObject TempBullet = Instantiate(Bullet, FirePoints[i].position, FirePoints[i].rotation);
            TempBullet.GetComponent<Rigidbody>().velocity = TempBullet.transform.forward * SetBulletSpeed;
            Destroy(TempBullet, DestroyTime);
        }
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

