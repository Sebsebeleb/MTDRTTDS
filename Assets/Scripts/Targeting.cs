using System.Collections.Generic;
using UnityEngine;
using System.Collections;

//Finds targets using a trigger collider, also handles priorities of targets
[RequireComponent(typeof(Collider2D))]
public class Targeting : MonoBehaviour {

    private List<GameObject> targets = new List<GameObject>();

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject GetCurrentTarget()
    {
        if (targets.Count == 0) {
            return null;
        }

        return targets[0];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject other = col.gameObject;
        if (IsValidTarget(other)) {
            targets.Add(other);   
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        GameObject other = col.gameObject;

        if (targets.Contains(other)) {
            targets.Remove(other);
        }
    }


    private bool IsValidTarget(GameObject target)
    {
        return true;
    }
}
