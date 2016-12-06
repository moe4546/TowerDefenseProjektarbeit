using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Vector3 positionOffset;

	private GameObject turret;
	private Renderer rend; 
	private Color startColor;

	void Start() {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

	void OnMouseDown() {
		if(turret != null) {
			Debug.Log ("Can't build there -TODO: Display on screen.");
			return;
		}

		// Build a turret
		GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
		turret = Instantiate (turretToBuild, transform.position + positionOffset, transform.rotation) as GameObject;
	}

	void OnMouseEnter() {
		rend.material.color = hoverColor;
	}

	void OnMouseExit() {
		rend.material.color = startColor;
	}
}
