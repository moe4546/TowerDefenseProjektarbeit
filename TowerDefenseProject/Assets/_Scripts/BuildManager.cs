using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

	// Singleton pattern
	public static BuildManager instance;

	public GameObject standardTurretPrefab;

	private GameObject turretToBuild;

	void Awake() {
		if(instance != null) {
			Debug.LogError ("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	void Start() {
		turretToBuild = standardTurretPrefab;
	}

	public GameObject getTurretToBuild() {
		return turretToBuild;
	}
}
