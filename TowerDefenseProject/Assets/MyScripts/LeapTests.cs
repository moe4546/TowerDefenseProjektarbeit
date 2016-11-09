using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class LeapTests : MonoBehaviour {

    LeapServiceProvider provider;

	// Use this for initialization
	void Start () {
        provider = GameObject.FindObjectOfType<LeapServiceProvider>();
	}
	
	// Update is called once per frame
	void Update () {

        Frame frame = provider.CurrentFrame;

        foreach (Hand hand in frame.Hands)
        {
            if(hand.PalmPosition.ToVector3() == transform.position+new Vector3(5f,5f,5f))
            {
                transform.position = hand.PalmPosition.ToVector3() +
                                     hand.PalmNormal.ToVector3() *
                                    (transform.localScale.y * .5f + .02f);
            }
        }
	}
}
