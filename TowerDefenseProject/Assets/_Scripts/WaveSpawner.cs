using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class WaveSpawner : MonoBehaviour {

	public Transform normalEnemy;
	public Transform quickEnemy;
	public Transform boss;
	public Text waveText;
	public Text countDownText;
	public Text scoreText;
	public int waveBelohnung;
	public int highscore;

	public Transform spawnPoint;
	public float timeBetweenEnemies = 5.5f;
	public int timeBetweenWaves = 5;

	private int waveIndex = 0;
    private GameObject[] actualEnemies;
	private bool spawnRunning;
	private Shop shop;
	private int difficulty = 1;

    void Start()
    {
		Invoke ("SpawnFirstWave", 15);
		shop = GameObject.Find ("GameMaster").GetComponent<Shop> ();
		spawnRunning = true;
		StartCoroutine (PlayWaveCountdown (15));
    }

	void Update()
    {
		if(waveIndex > 0)
        {
            actualEnemies = GameObject.FindGameObjectsWithTag("Enemy");
			if(actualEnemies.Length <= 0 && spawnRunning == false)
            {
				highscore++;
				scoreText.text = "Score: " + highscore.ToString ();
                Debug.Log("wave dead");
                switch(waveIndex)
                {
				case 1:
					shop.addMoney (waveBelohnung);
					Debug.Log ("Second wave");
					spawnRunning = true;
					Invoke ("SpawnSecondWave", timeBetweenWaves);
					StartCoroutine (PlayWaveCountdown (timeBetweenWaves));
                    break;
                case 2:
					shop.addMoney (waveBelohnung);
                    Debug.Log("Third wave");
					spawnRunning = true;
					Invoke ("SpawnThirdWave", timeBetweenWaves); 
					StartCoroutine (PlayWaveCountdown (timeBetweenWaves));
                    break;
                case 3:
					shop.addMoney (waveBelohnung);
                    Debug.Log("Fourth wave");
					spawnRunning = true;
					Invoke ("SpawnFourthWave", timeBetweenWaves);
					StartCoroutine (PlayWaveCountdown (timeBetweenWaves));
                    break;
                case 4:
					shop.addMoney (waveBelohnung);
                    Debug.Log("Fifth wave");
					spawnRunning = true;
					Invoke ("SpawnFifthWave", timeBetweenWaves);
					StartCoroutine (PlayWaveCountdown (timeBetweenWaves));
                    break;
				case 5:
					waveIndex = 0;
					difficulty = difficulty * 2;
					Start ();
                    break;
                }
            }
        }
	}

	IEnumerator PlayWaveCountdown(int count)
	{
		waveText.text = "Next Wave in";
		for(int i = count; i > 0; i--)
		{
			countDownText.text = i.ToString ();
			yield return new WaitForSeconds (1f);
		}
		countDownText.text = "";
		waveText.text = "";

	}


    private void SpawnFirstWave()
    {
		waveIndex++;
        StartCoroutine(SpawnEnemy(normalEnemy, 5, 2f));
	}

    private void SpawnSecondWave()
    {
        waveIndex++;
        StartCoroutine(SpawnEnemy(normalEnemy, 8, 2f));
    }

    private void SpawnThirdWave()
    {
        waveIndex++;
		StartCoroutine (SpawnEnemy (quickEnemy, 15, 2f));
    }

    private void SpawnFourthWave()
    {
		waveIndex++;
		StartCoroutine (SpawnEnemy (quickEnemy, 10, 3f));
		StartCoroutine (SpawnEnemy (normalEnemy, 10, 3f));
    }

    private void SpawnFifthWave()
    {
        waveIndex++;
		StartCoroutine (SpawnEnemy (boss, 1, 0f));
    }

	IEnumerator SpawnEnemy (Transform enemy, int count, float spawnTime)
	{
		for (int i = 0; i < count; i++) {
			Transform insEnemy = Instantiate (enemy, spawnPoint.position, spawnPoint.rotation) as Transform;
			insEnemy.GetComponent<Enemy> ().setDifficulty (difficulty);
            yield return new WaitForSeconds(spawnTime);
        }
		spawnRunning = false;
	}
}
