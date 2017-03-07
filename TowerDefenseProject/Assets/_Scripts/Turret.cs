using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	private Transform target;

	[Header("Attributes")]
	public float range = 15f;
	public float turnSpeed = 10f;
	// shots per second
	public float fireRate = 1f;


	[Header("Unity Setup Fields")]
	private float fireCountdown = 0f;
	public Transform partToRotate;
	public GameObject bulletPrefab;
	public Transform firePoint;
	private AudioSource shootSound;

	void Awake() {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
		shootSound = GetComponent<AudioSource> ();
	}

	void UpdateTarget() {
        
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

        if(enemies.Length > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
                
				if(distanceToEnemy <= range){
					target = nearestEnemy.transform;
				} else {
					target = null;
				}
            }
        }

		if(nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
		} else {
			target = null;
		}
	}

    void Update()
    {
        if (target == null)
        {
            return;
        }

        // lock on next target
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Debug.Log("shoot");
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

	void Shoot() {
        Debug.Log("shoot");
		GameObject bulletGO = Instantiate (bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
		Bullet bullet = bulletGO.GetComponent<Bullet> ();
		if(bullet != null) {
			bullet.SetTarget (target);
			shootSound.Play ();
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other);
	}
}

