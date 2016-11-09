using UnityEngine;
using System.Collections;
using System;
using Leap.Unity;
using Leap;

public class SnapWhenTouch : MonoBehaviour {

    public float range = 0.13f;
    private LeapServiceProvider provider;

	// Use this for initialization
	void Start () {
        provider = FindObjectOfType<LeapServiceProvider>() as LeapServiceProvider;
    }
	
	// Update is called once per frame
	void Update () {
        UpdateLeftHand();
	}

    private void UpdateLeftHand()
    {
        Frame frame = provider.CurrentFrame;

        foreach (Hand hand in frame.Hands)
        {
            float distanceToHand = Vector3.Distance(transform.position, hand.PalmPosition.ToVector3());
            if (hand.IsLeft && distanceToHand <= range)
            {
                transform.position = hand.PalmPosition.ToVector3() +
                                     hand.PalmNormal.ToVector3() *
                                    (transform.localScale.y * .5f + .02f);
                transform.rotation = hand.Basis.rotation.ToQuaternion();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
