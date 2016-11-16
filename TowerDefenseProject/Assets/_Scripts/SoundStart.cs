using UnityEngine;
using System.Collections;

public class SoundStart : MonoBehaviour {

    private MusicManager musicManager;

    // Use this for initialization
    void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
	}
}
