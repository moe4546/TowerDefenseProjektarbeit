using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider diffSlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		diffSlider.value = PlayerPrefsManager.GetDifficulty ();
	}
	
 	public void BackAndSave(){
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (diffSlider.value);
		levelManager.LoadLevel ("01a Start");
	}

	void Update() {
		musicManager.ChangeVolume (volumeSlider.value);
	}

	public void SetDefault(){
		volumeSlider.value = 0.5f;
		diffSlider.value = 1f;
	}
}
