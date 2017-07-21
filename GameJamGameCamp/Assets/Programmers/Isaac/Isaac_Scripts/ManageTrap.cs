using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Trick the player into walking into the trap
//Random respawn is on line 36
public class ManageTrap : MonoBehaviour {
    public GameObject PS;
    public GameObject trap;
    public float rotSpeed = 1.0f;
    private float cooldown;
    private bool Activated = false;
    float DT;
	// Use this for initialization
	void Start () {
        trap = GameObject.FindGameObjectWithTag("Trap");
        cooldown = -1;
    }
    public float resettime = 10;
    // Update is called once per frame
    void Update () {
        DT = Time.deltaTime;
        transform.Rotate(transform.up * rotSpeed * Random.Range((float)0, (float)5));
        if (cooldown > -1)
        {
            cooldown -= DT;
        }
        if(cooldown < (resettime - .5f) && Activated)
        {
            HitBox.SetActive(false);
        }
        if (cooldown <= 0 && Activated)
        {
            spawnTrap();
        }
    }

    void spawnTrap()
    {
        Activated = false;
        GameObject newTrap = Instantiate(trap, new Vector3(Random.Range((float)-10, (float)10), 1, Random.Range((float)-10, (float)10)), PS.transform.rotation);
        transform.Find("OuterTrap").gameObject.SetActive(true);
        transform.Find("HurtParticle").gameObject.SetActive(true);
        gameObject.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public GameObject HitBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !Activated)
        {
            cooldown = resettime;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            transform.Find("OuterTrap").gameObject.SetActive(false);
            transform.Find("HurtParticle").gameObject.SetActive(false);

            HitBox.SetActive(true);

            GameObject temp = Instantiate(PS, other.transform.position, PS.transform.rotation);
            Destroy(temp, 1.0f);
            Activated = true;
        }
    }
}
