using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemyMove : MonoBehaviour
{
    public Vector3 TargetPosition;

	// Use this for initialization
	void Start ()
	{
	    Seeker seeker = GetComponent<Seeker>();
	    seeker.StartPath(transform.position, TargetPosition, OnPathComplete);
	}

    void OnPathComplete(Path p)
    {
        Debug.Log("Hello path");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
