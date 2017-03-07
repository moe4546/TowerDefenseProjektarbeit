using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

	public Vector3 positionOffsetTower1 = new Vector3(0f, 0.03f, 0f);
	public Vector3 positionOffsetTower2 = new Vector3(-0.02f, 0.08f, 0f);

	private GameObject actualPlacedTurret;
    private Shop shop;

    void Awake()
    {
        shop = GameObject.Find("GameMaster").GetComponent<Shop>();
    }

	public void BuildTurret(GameObject turret) {

        if(!turret) {
            return;
        }

		if(actualPlacedTurret) {
			Debug.Log ("Can't build there");
			return;
		}

		if(turret.tag == "selectedTower1")
		{
			if(shop.PurchaseTower1() == false)
			{
				Destroy(turret);
				return;
			}
			turret.transform.position = transform.position + positionOffsetTower1;
		} 
		else if(turret.tag == "selectedTower2")
		{
			if(shop.PurchaseTower2() == false)
			{
				Destroy(turret);
				return;
			}
			turret.transform.position = transform.position + positionOffsetTower2;
		}
			
        turret.tag = "Tower";

        // Build a turret
        actualPlacedTurret = turret;
        turret.GetComponent<LineRenderer>().enabled = false;
        turret.GetComponent<Building>().enabled = false;
        turret.transform.parent = transform;
        turret.transform.rotation = transform.rotation;
		turret.GetComponent<Turret> ().enabled = true;
        transform.parent.GetComponent<AudioSource>().Play();
        GameObject.Find("Scripts").GetComponent<Gestures>().actualTower = null;
    }

	
}
