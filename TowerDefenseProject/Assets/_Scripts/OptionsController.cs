using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider diffSlider;
	public LevelManager levelManager;
    public float speed;

    private MusicManager musicManager;
    private bool optionPressed;
    private GameObject optionCanvas;
    private GameObject startCanvas;
    private GameObject world;
    private bool worldLeft;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
        musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
        optionCanvas = GameObject.Find("CanvasOptions");
        startCanvas = GameObject.Find("CanvasStart");
        world = GameObject.Find("World");
        worldLeft = true;
        optionCanvas.SetActive(false);
    }
	
 	public void BackAndSave(){
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (diffSlider.value);
        optionPressed = false;
        optionCanvas.SetActive(false);
        startCanvas.SetActive(true);
		// Close Options
	}

	void Update() {
        // When optionmenu is open, change Mastervolume to valid Slider
        if (optionPressed)
        {
            musicManager.ChangeVolume (volumeSlider.value);
        }
        moveBackgroundWorld();
	}

	public void SetDefault(){
		volumeSlider.value = 0.2f;
		diffSlider.value = 1f;
	}

    public void OptionPress()
    {
        // Öffne Canvas
        Debug.Log("Open Options");
        Debug.Log(optionCanvas);
        optionPressed = true;
        optionCanvas.SetActive(true);
        startCanvas.SetActive(false);
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        diffSlider.value = PlayerPrefsManager.GetDifficulty();
    }

    private void moveBackgroundWorld()
    {
        if (optionPressed)
        {
            // go right
            if (world.transform.position.x >= 90f)
            {
                return;
            }
            world.transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        } 
        else
        {
            // go left
            if (world.transform.position.x <= -70f)
            {
                return;
            }
            world.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }
}
