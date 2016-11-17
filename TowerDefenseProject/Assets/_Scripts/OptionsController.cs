using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider diffSlider;
	public LevelManager levelManager;

	private MusicManager musicManager;
    private bool optionPressed;
    private GameObject optionCanvas;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
        musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
        optionCanvas = GameObject.Find("CanvasOptions");
        optionCanvas.SetActive(false);
    }
	
 	public void BackAndSave(){
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (diffSlider.value);
        optionPressed = false;
        optionCanvas.SetActive(false);
		// Close Options
	}

	void Update() {
        // When optionmenu is open, change Mastervolume to valid Slider
        if (optionPressed)
        {
            musicManager.ChangeVolume (volumeSlider.value);
        }
		
	}

	public void SetDefault(){
		volumeSlider.value = 0.5f;
		diffSlider.value = 1f;
	}

    public void OptionPress()
    {
        // Öffne Canvas
        Debug.Log("Open Options");
        Debug.Log(optionCanvas);
        optionPressed = true;
        optionCanvas.SetActive(true);
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        diffSlider.value = PlayerPrefsManager.GetDifficulty();
    }
}
