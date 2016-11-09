using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class SnapWithFingers : MonoBehaviour {

    public float range = 0.13f;
    private LeapServiceProvider provider;

    // Use this for initialization
    void Start()
    {
        provider = FindObjectOfType<LeapServiceProvider>() as LeapServiceProvider;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHand();
        
    }

    private void UpdateHand()
    {
        Frame frame = provider.CurrentFrame;
        bool FingerInNear = false;

        foreach (Hand hand in frame.Hands)
        {       
            foreach(Finger finger in hand.Fingers)
            {
                float fingerDistanceToObject = Vector3.Distance(transform.position, finger.TipPosition.ToVector3());
                if(fingerDistanceToObject <= range)
                {
                    FingerInNear = true;
                } else
                {
                    FingerInNear = false;
                }
            }
        }

        if(FingerInNear == true)
        {
            SnapObjectToHand();
        }

    }

    void SnapObjectToHand()
    {
        Frame frame = provider.CurrentFrame;
        foreach (Hand hand in frame.Hands)
        {
               transform.position = hand.PalmPosition.ToVector3() +
                                    hand.PalmNormal.ToVector3() *
                                   (transform.localScale.y * .5f + .02f);
               transform.rotation = hand.Basis.rotation.ToQuaternion();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
