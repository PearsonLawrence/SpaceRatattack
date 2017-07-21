using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{

    public float FireRate = .5f, SetFireRate;
    public float GrenadeSpeed, SetGrenadeSpeed;
    public float DestroyTime = 3;
    public GameObject Grenade;
    float DT;
    public void Update()
    {
        DT = Time.deltaTime;
        
        SetFireRate -= DT;

    }

    public Transform FirePoint;

    private void Start()
    {
        
        SetGrenadeSpeed = GrenadeSpeed;
    }

    public void SpawnGrenade()
    {
        SetGrenadeSpeed = GrenadeSpeed;
        SetFireRate = FireRate;
        GameObject TempGrenade = Instantiate(Grenade, FirePoint.position, FirePoint.rotation);
        TempGrenade.GetComponent<Rigidbody>().velocity = TempGrenade.transform.forward * SetGrenadeSpeed;
        Destroy(TempGrenade, DestroyTime);
    }

    public void Fire(float DT, bool IsFiring)
    {
       
        if (SetFireRate <= 0 && IsFiring)
        {
            SpawnGrenade();
        }
    }
  }   
