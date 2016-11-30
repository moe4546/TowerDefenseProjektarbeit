using UnityEngine;
using System.Collections;

public class Schrifrolle : MonoBehaviour {

	public GameObject optionCanvas;
	public GameObject startCanvas;
	
	public void setMenu(){
		if(OptionsController.optionPressed == true){
			optionCanvas.SetActive (true);
		} else {
			startCanvas.SetActive (true);
		}
	}
}
