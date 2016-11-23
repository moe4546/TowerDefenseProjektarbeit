using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFF_KEY = "difficulty";

	public static void SetMasterVolume(float volume) {
		if(volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		}
		else {
			Debug.LogError ("Master volume out of range");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void SetDifficulty (float diff){
		if(diff >= 0f && diff <= 3f){
			PlayerPrefs.SetFloat (DIFF_KEY, diff);
		} 
		else {
			Debug.Log ("Difficulty out of range");
		}
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (DIFF_KEY);
	}
}
