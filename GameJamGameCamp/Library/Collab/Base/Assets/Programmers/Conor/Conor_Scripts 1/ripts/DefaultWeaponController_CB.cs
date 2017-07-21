using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeaponController_CB : MonoBehaviour {

    public float FireRate;
    public float SetFireRate;
    public float BulletSpeed, SetBulletSpeed;

    public GameObject Bullet;


    public Transform FirePoint;

    private void Start()
    {
        SetFireRate = 0
    }


    public void Fire(float deltaTime, bool IsFiring);
    {
        if(SetFireRate <= 0 && IsFiring)
        {
        SetFireRate = FireRate;
        
        
        SetFireRate -= deltaTime;

        if(SetFireRate <= 0)
        {
        private void OnNetworkInstantiate(NetworkMessageInfo info)
    {
        GameObject TempBullet = Instantiate(Bullet, transform.position, FirePoint.rotation);
        TempBullet.GetComponent<Rigidbody>().velocity = TempBullet.transform.forward * SetBulletSpeed;
    }

}

    }

}
