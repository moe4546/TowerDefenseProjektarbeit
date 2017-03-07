using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public LevelManager levelManager;

	private float time = 4f;

	void Update() {
		time -= Time.deltaTime;
		if(time <= 0f) {
			levelManager.LoadLevel ("01 Start");
		}
	}
}
