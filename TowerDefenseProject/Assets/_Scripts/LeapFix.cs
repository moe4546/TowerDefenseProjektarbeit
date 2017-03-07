using UnityEngine;
using System.Collections;

public class LeapFix : MonoBehaviour {

	private GameObject duplicateRigidHand_R;
	private GameObject duplicateRigidHand_L;
	private GameObject duplicateCapsuleHand_R;
	private GameObject duplicateCapsuleHand_L;
	private GameObject duplicateHandAtt_R;
	private GameObject duplicateHandAtt_L;

	void Start () {
	    
	}
	
	void Update ()
    {
	    foreach(Transform child in transform)
        {
            if(!child.gameObject.active)
            {
                child.gameObject.SetActive(true);
            }
        }





		/*
		duplicateRigidHand_L = GameObject.Find ("RigidRoundHand_L(Clone)");
		duplicateRigidHand_R = GameObject.Find ("RigidRoundHand_R(Clone)");
		duplicateCapsuleHand_R = GameObject.Find ("CapsuleHand_R(Clone)");
		duplicateCapsuleHand_L = GameObject.Find ("CapsuleHand_L(Clone)");
		duplicateHandAtt_L = GameObject.Find ("HandAttachments-L(Clone)");
		duplicateHandAtt_R = GameObject.Find ("HandAttachments-R(Clone)");

		if(duplicateRigidHand_L) 
		{
			Destroy (duplicateRigidHand_L);
		}
		if(duplicateRigidHand_R)
		{
			Destroy (duplicateRigidHand_R);
		}
		if(duplicateCapsuleHand_L)
		{
			Destroy (duplicateCapsuleHand_L);
		}
		if(duplicateCapsuleHand_R)
		{
			Destroy (duplicateCapsuleHand_R);
		}
		if(duplicateHandAtt_L)
		{
			Destroy (duplicateHandAtt_L);
		}
		if(duplicateHandAtt_R)
		{
			Destroy (duplicateHandAtt_R);
		}*/
	}
}
