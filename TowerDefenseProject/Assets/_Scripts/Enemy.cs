using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed = 0.5f;
	public float hitpoints = 2f;
	public int money = 20;

	private Transform target;
	private int wavepointIndex = 0;
	private Player player;
	private Shop shop;

	void Start() {
		// First target is the first waypoint
		target = Waypoints.points [0];
		player = GameObject.Find ("GameMaster").GetComponent<Player> ();
		shop = GameObject.Find ("GameMaster").GetComponent<Shop> ();
	}

	void Update() {
		// Move enemy to the next waypoint
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);

		// if enemy is close enough to waypoint, find the next waypoint
		if(Vector3.Distance(transform.position, target.position) <= 0.009f) {
			GetNextWaypoint ();
		}
	}

	void GetNextWaypoint() {
		// Destroy Enemy when he arrives at the end
		if(wavepointIndex >= Waypoints.points.Length-1) {
			Destroy (gameObject);
			player.LoseHealth ();
			return;
		}

		// Get next available Waypoint
		wavepointIndex++;
		target = Waypoints.points [wavepointIndex];
	}

	public void TakeDamage(float damage)
	{
		hitpoints -= damage;
		if(hitpoints <= 0f)
		{
			Destroy (gameObject);
			shop.addMoney (money);
		}
	}

	public void setDifficulty(int diff)
	{
		hitpoints = hitpoints * diff;
	}
}
