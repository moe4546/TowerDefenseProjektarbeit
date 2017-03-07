using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public LevelManager levelmanager;
	public Text highscore;

	void Start()
	{
		highscore.text = levelmanager.GetHighscore().ToString();
	}
}
