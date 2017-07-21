using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeaponController : MonoBehaviour {

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

    public void Fire(float DT, bool IsFiring)
    {
        SetFireRate -= DT;

        if(SetFireRate <= 0 && IsFiring)
        {
            SpawnBullet();
        }

    }

    public IcallShotgun ShotGun;
    public Laser_Script_AM Laser;
    public RocketLauncher rocket;
    public void FireSpecialWeapon(float DT, bool IsFiringSpecial)
    {

        if (IsFiringSpecial)
        {

            CurrentSepcialWeapon = DesiredSpecialWeapon;
            switch (CurrentSepcialWeapon)
            {
                case "":
                    
                    break;

                case "ShotGun":
                    ShotGun.Fire(DT, IsFiringSpecial);
                    break;

                case "RPG":
                    rocket.Fire(DT, IsFiringSpecial);
                    break;

                case "Laser":
                    Laser.Fire(IsFiringSpecial);
                    break;
            }
        }
    }
}
