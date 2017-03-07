using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    public float rayRange = 50f;

    Ray buildRay;
    RaycastHit buildHit;
    LineRenderer buildLine;
    int buildMask;
    Collider lastNode;
    bool firstRay = true;
    GameObject tower;

    void Awake()
    {
        buildLine = GetComponent<LineRenderer>();
        buildMask = LayerMask.GetMask("Buildable");
        tower = gameObject;
    }

    public void DisableBuildLine()
    {
        buildLine.enabled = false;
    }

    void DrawBuildingLine()
    {
        buildLine.enabled = true;
        buildLine.SetPosition(0, transform.position);

        buildRay.origin = transform.position;
        buildRay.direction = -transform.up;

        if(Physics.Raycast(buildRay, out buildHit, rayRange, buildMask))
        {
            Collider actualNode = buildHit.collider;
            
            if (firstRay)
            {
                lastNode = actualNode;
                firstRay = false;
            }

            if(actualNode != lastNode)
            {
                Debug.Log("other node");
				lastNode.GetComponent<MeshRenderer>().enabled = false;
                lastNode = actualNode;
                return;
            }
         
            if(actualNode)
            {
                
                lastNode = actualNode;
                buildLine.SetPosition(1, buildHit.point);
				actualNode.GetComponent<MeshRenderer> ().enabled = true;
				actualNode.GetComponent<MeshRenderer>().material.color = Color.green;
                if(buildHit.distance < 0.08f)
                {
                    // Build tower
					actualNode.GetComponent<MeshRenderer>().enabled = false;
                    Build(actualNode);
                }
            }
            else
            {
                buildLine.SetPosition(1, buildRay.origin + buildRay.direction * rayRange);
            }
        }
    }

    void Build(Collider node)
    {
        node.GetComponent<Node>().BuildTurret(tower);
    }

    void Update()
    {
        DrawBuildingLine();
    }


}
