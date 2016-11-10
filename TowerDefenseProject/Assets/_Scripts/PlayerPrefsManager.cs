using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFF_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume(float volume) {
		if(volume > 0f && volume < 1f){
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		}
		else {
			Debug.LogError ("Master volume out of range");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel(int level){
		if(level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); // Use 1 for true
		}
		else {
			Debug.Log ("Level not available");
		}
	}

	public static bool IsLevelUnlocked(int level){
		if(level <= Application.levelCount - 1) {
			int resultAsInt = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
			if(resultAsInt == 1){
				return true;
			}else {
				return false;
			}
		} 
		else {
			Debug.Log ("Level not available");
			return false;
		}
	}

	public static void SetDifficulty (float diff){
		if(diff >= 0f && diff <= 1f){
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
