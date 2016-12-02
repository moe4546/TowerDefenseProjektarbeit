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

	void Start() {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if(distanceToEnemy < shortestDistance) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if(nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
		} else {
			target = null;
		}
	}

	void Update() {
		if(target == null) {
			return;
		}

		// lock on next target
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp (partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		if(fireCountdown <= 0f) {
			Shoot ();
			fireCountdown = 1f / fireRate;
		}
		fireCountdown -= Time.deltaTime;
	}

	void Shoot() {
		GameObject bulletGO = Instantiate (bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
		Bullet bullet = bulletGO.GetComponent<Bullet> ();
		if(bullet != null) {
			bullet.SetTarget (target);
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
