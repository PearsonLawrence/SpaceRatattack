using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeaponController : MonoBehaviour {

    public float FireRate = .5f, SetFireRate;
    public float BulletSpeed, SetBulletSpeed;
  
    public GameObject Bullet;

    public Transform FirePoint;

    private void Start()
    {
        SetFireRate = 0;
        SetBulletSpeed = BulletSpeed;
    }

    public void Fire(float DeltaTime, bool IsFiring)
    {
        SetFireRate -= DeltaTime;

        if(SetFireRate <= 0 && IsFiring)
        {
          SetBulletSpeed = BulletSpeed;
          SetFireRate = FireRate;
          GameObject TempBullet = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
          TempBullet.GetComponent<Rigidbody>().velocity = TempBullet.transform.forward * SetBulletSpeed;
        }

    }


}
