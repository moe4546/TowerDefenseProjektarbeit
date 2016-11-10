using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class LeapSnap : MonoBehaviour {

    LeapServiceProvider provider;

    void Start()
    {
        provider = FindObjectOfType<LeapServiceProvider>() as LeapServiceProvider;
    }

    void Update()
    {
        Frame frame = provider.CurrentFrame;
        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsLeft)
            {
                transform.position = hand.PalmPosition.ToVector3() +
                                     hand.PalmNormal.ToVector3() *
                                    (transform.localScale.y * .5f + .02f);
                transform.rotation = hand.Basis.rotation.ToQuaternion();
            }
        }
    }
}
