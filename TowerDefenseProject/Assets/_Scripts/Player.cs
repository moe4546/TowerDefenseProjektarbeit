using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public float health = 5f;
	public Text healthText;
	public LevelManager levelManager;
	public WaveSpawner waveSpawner;

	void Start()
	{
		healthText.text = "Health: " + health.ToString ();
		waveSpawner = GameObject.Find ("GameMaster").GetComponent<WaveSpawner> ();
	}

	public void LoseHealth()
	{
		health--;
		healthText.text = "Health: " + health.ToString ();
		if(health <= 0f)
		{
			Debug.Log("Game Over");
			levelManager.SetHighscore (waveSpawner.highscore);
			levelManager.LoadLevel ("03b Lose");
		}
	}
}
