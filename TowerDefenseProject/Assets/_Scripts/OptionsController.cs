using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider diffSlider;
	public LevelManager levelManager;
    public float speed;
	public Animator schriftrollenAnimator;


    private MusicManager musicManager;
	public static bool optionPressed;
    private GameObject optionCanvas;
    private GameObject startCanvas;
    private bool worldLeft;

	void Awake () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
        musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
        optionCanvas = GameObject.Find("CanvasOptions");
        startCanvas = GameObject.Find("CanvasStart");
        optionCanvas.SetActive(false);
		schriftrollenAnimator = GameObject.Find ("Schriftrolle").GetComponent<Animator> ();
    }
	
 	public void BackAndSave(){
		Debug.Log ("Save Options");
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (diffSlider.value);
        optionPressed = false;
        optionCanvas.SetActive(false);
		schriftrollenAnimator.SetTrigger ("Roll");
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
		volumeSlider.value = 0.2f;
		diffSlider.value = 1f;
	}

    public void OptionPress()
    {
        Debug.Log("Open Options");
        optionPressed = true;
        startCanvas.SetActive(false);
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        diffSlider.value = PlayerPrefsManager.GetDifficulty();
		schriftrollenAnimator.SetTrigger ("Roll");
    }
}
