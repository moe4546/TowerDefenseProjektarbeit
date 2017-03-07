using UnityEngine;

public class Waypoints : MonoBehaviour {

	public static Transform[] points;

	void Awake(){
		// Number of children of the Waypoints object
		points = new Transform[transform.childCount];

		// Fill array with child waypoints
		for(int i = 0; i < points.Length; i++) {
			points[i] = transform.GetChild(i);
		}
	}
}
