using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class Gestures : MonoBehaviour {

	public GameObject menu;
	public GameObject actualMenu;
	private LeapServiceProvider provider;

	void Start() {
		provider = FindObjectOfType<LeapServiceProvider>() as LeapServiceProvider;
	}

	public void OpenTowerMenu(){
		Debug.Log ("Open Tower Menu");
		Transform leftHand = GameObject.Find ("CapsuleHand_L").transform;
		GameObject menuIns = Instantiate (menu, leftHand) as GameObject;
		actualMenu = menuIns;
	}

	public void CloseTowerMenu(){
		Debug.Log ("Close Menu");
		Destroy (actualMenu);
	}

	void Update() {
		Frame frame = provider.CurrentFrame;
		foreach(Hand hand in frame.Hands) 
		{
			if(hand.IsLeft && actualMenu)
			{
				//TODO: Dont hardcode this
				actualMenu.transform.position = hand.PalmPosition.ToVector3 () + new Vector3(0, 0.1f, 0);
				actualMenu.transform.rotation = hand.Basis.rotation.ToQuaternion();
			}
		}
	}
}
