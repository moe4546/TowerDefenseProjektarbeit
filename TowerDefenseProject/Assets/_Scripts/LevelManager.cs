using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;
	private int highscore;

	void Start(){
		if(autoLoadNextLevelAfter != 0){
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name) {		
		Debug.Log ("Level load requested for: " + name);
        SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log ("I Want to quit!");
		Application.Quit ();
	}

	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void SetHighscore(int score)
	{
		highscore = score;
	}

	public int GetHighscore()
	{
		return highscore;
	}
}
