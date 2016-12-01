using UnityEngine;
using System.Collections;

public class Schrifrolle : MonoBehaviour {

	public GameObject optionCanvas;
	public GameObject startCanvas;
	private AudioSource openSound;

	void Start(){
		openSound = GetComponent<AudioSource> ();
	}
	
	public void setMenu(){
		if(OptionsController.optionPressed == true){
			optionCanvas.SetActive (true);
		} else {
			startCanvas.SetActive (true);
		}
	}

	void playSound(){
		openSound.Play ();
	}
}
