using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

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
}
