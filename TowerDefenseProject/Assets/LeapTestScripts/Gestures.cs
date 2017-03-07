using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Leap;
using Leap.Unity;

public class Gestures : MonoBehaviour {

	public GameObject menu;
	public GameObject tower1;
	public GameObject tower2;
    public GameObject actualTower;
    public Transform leapCamera;
    public Transform cameraTarget;
    public float cameraRotationSpeed = 40f;
	public Vector3 menuAbstand = new Vector3(0, 0.06f, 0.05f);
	public Vector3 towerAbstand = new Vector3 (0, -0.05f, 0.04f);

	private GameObject actualMenu;
	private LeapServiceProvider provider;
    private bool rotateRight = false;
    private bool rotateLeft = false;
    private GameObject island;
	private AudioSource errorSound;


	void Awake() {
		provider = FindObjectOfType<LeapServiceProvider>() as LeapServiceProvider;
        island = GameObject.FindGameObjectWithTag("Island");
		errorSound = GetComponent<AudioSource> ();
	}

	public void OpenTowerMenu(){
		Debug.Log ("Open Tower Menu");
		Transform leftHand = GameObject.FindGameObjectWithTag ("LeftHand").transform;
		actualMenu = Instantiate (menu, leftHand) as GameObject;
	}

	public void CloseTowerMenu(){
		Debug.Log ("Close Menu");
		Destroy (actualMenu);
		actualMenu = null;
	}

	public void clickButton1(){
		Debug.Log ("Klicked Button 1");
		if(GameObject.FindGameObjectWithTag ("selectedTower2") || GameObject.FindGameObjectWithTag ("selectedTower1"))
		{
			return;
		}
		Transform rightHand = GameObject.FindGameObjectWithTag("RightHand").transform;
		GameObject towerIns = Instantiate (tower1, rightHand) as GameObject;
		towerIns.tag = "selectedTower1";
        towerIns.GetComponent<Turret>().enabled = false;
	}

	public void clickButton2(){
		Debug.Log ("Klicked Button 2");
		if(GameObject.FindGameObjectWithTag ("selectedTower2") || GameObject.FindGameObjectWithTag ("selectedTower1"))
		{
			return;
		}
		//Transform rightHand = GameObject.Find ("CapsuleHand_R").transform;
		Transform rightHand = GameObject.FindGameObjectWithTag("RightHand").transform;
		GameObject towerIns = Instantiate (tower2, rightHand) as GameObject;
		towerIns.tag = "selectedTower2";
		towerIns.GetComponent<Turret>().enabled = false;
	}

	public void Cancel()
	{
		GameObject t1 = GameObject.FindGameObjectWithTag ("selectedTower1");
		GameObject t2 = GameObject.FindGameObjectWithTag ("selectedTower2");
		GameObject[] nodes = GameObject.FindGameObjectsWithTag ("Node");

		if(t1) {
			Destroy (t1);
		}
		if(t2) {
			Destroy (t2);
		}

		foreach(GameObject node in nodes)
		{
			node.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	void Update() {
        // Create reference, when a tower is selected
		actualTower = GameObject.FindGameObjectWithTag ("selectedTower1");
		if(!actualTower)
		{
			actualTower = GameObject.FindGameObjectWithTag ("selectedTower2");
		}
		
		Frame frame = provider.CurrentFrame;
		foreach(Hand hand in frame.Hands) 
		{
			if(hand.IsLeft && actualMenu)
			{
				// Snap Menu to left hand
				Vector3 lookDir = GameObject.Find ("MenuLookDir").transform.position - hand.PalmPosition.ToVector3 ();
				actualMenu.transform.position = hand.PalmPosition.ToVector3 () + 0.3f * lookDir;
                actualMenu.transform.rotation = leapCamera.rotation;
			}

			if(hand.IsRight && actualTower)
			{
				// Snap Tower to right hand
				actualTower.transform.position = hand.PalmPosition.ToVector3 () + towerAbstand;
			}
		}
	}

	void FixedUpdate() 
	{
		if(rotateLeft == true)
		{
			leapCamera.LookAt(cameraTarget);
			//leapCamera.transform.Translate(Vector3.left * Time.deltaTime);
			leapCamera.transform.RotateAround(cameraTarget.position, Vector3.up, 100 * Time.deltaTime);
		}
	}

    public void RotateCameraRight()
    {
        rotateRight = true;
    }

    public void RotateCameraLeft()
    {
        rotateLeft = true;
    }

    public void StopCameraRotation()
    {
        rotateRight = false;
        rotateLeft = false;
    }
    
    public void PointLeft()
    {
        Debug.Log("Left");

    }

    public void PointRight()
    {
        Debug.Log("Right");
    }
}
