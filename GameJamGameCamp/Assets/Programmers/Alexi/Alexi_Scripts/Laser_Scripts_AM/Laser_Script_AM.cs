using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Script_AM : MonoBehaviour {

	LineRenderer line;
	public ParticleSystem PS;
    

	// Use this for initialization
	void Start () 
	{
		line = gameObject.GetComponent<LineRenderer> ();
		line.enabled = false;
		PS.Stop ();
        PS.Clear ();


		//Screen.lockCursor = true;
	}
    float DT;
    float DamageTimer;
    public float SetDamageTimer;
    public float DamageAmount;
	// Update is called once per frame
	void Update () 
	{
        DT = Time.deltaTime;
        DamageTimer -= DT;
	}

    public void Fire(bool IsFiring)
    {
        if (IsFiring)
        {
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");
        }
    }

	IEnumerator FireLaser ()
	{
		line.enabled = true;

		while (Input.GetMouseButton(1)) 
		{
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;

			line.SetPosition (0, ray.origin);

            PS.Play ();


			if (Physics.Raycast (ray, out hit, 100)) 
			{
				line.SetPosition (1, hit.point);
			} 
		    else 
			{
				line.SetPosition (1, ray.GetPoint (100));
			}

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<Health_Component>() != null || hit.collider.GetComponent<Boss_Health_Component>() != null)
                {
                    if(DamageTimer <= 0)
                    {
                        hit.collider.GetComponent<Health_Component>().AddDamage(DamageAmount);
                        DamageTimer = SetDamageTimer;
                    }
                }
            }

            yield return null;
		}

		line.enabled = false;
        PS.Stop ();
		PS.Clear ();

	}

	/*while laser hts enemy, enemy takes damage
	 * not sure how to do this
	 * 
	 * How to make particles go away immediatelly after system stops?
	 * How to stop particles from going through walls?
	 * */
}
