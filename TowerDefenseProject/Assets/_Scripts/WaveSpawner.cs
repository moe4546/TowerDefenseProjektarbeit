using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform spawnPoint;
	public float timeBetweenWaves = 5.5f;
	public Text waveCountdownText;

	private float countDown = 2f;
	private int waveIndex = 0;

	void Update() {
		if(countDown <= 0f) {
			StartCoroutine (SpawnWave());
			countDown = timeBetweenWaves;
		}

		countDown -= Time.deltaTime;
		waveCountdownText.text = Mathf.Round(countDown).ToString();
	}

	IEnumerator SpawnWave() {
		waveIndex++;
		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy ();
			yield return new WaitForSeconds (0.5f);
		}
	}

	void SpawnEnemy() {
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
