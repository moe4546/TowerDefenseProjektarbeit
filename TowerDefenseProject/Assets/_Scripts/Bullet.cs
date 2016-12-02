using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private Transform target;
	public float speed = 70f;
	public GameObject impactEffect;

	public void SetTarget(Transform _target) {
		target = _target;
	}

	void Update () {
		if(target == null) {
			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		// Bullet hit target
		if(dir.magnitude <= distanceThisFrame) {
			HitTarget ();
		}

		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
	}

	void HitTarget() {
		GameObject effIns = Instantiate (impactEffect, transform.position, transform.rotation) as GameObject;
		Destroy (effIns, 2f);

		Destroy (target.gameObject);

		Destroy (gameObject);
	}
}
