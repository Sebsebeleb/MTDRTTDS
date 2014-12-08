using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemyMove : MonoBehaviour
{
    public Vector3 TargetDestination;
    private Vector3 NextWaypoint;

    public float WaypointCheckRadius = 0.2f;
    public float MovementSpeed = 0.4f;

    private Path path;
    private List<Vector3> waypointList = new List<Vector3>();
    private int waypointCount = 0;
    private bool isMoving;
    private Seeker seeker;

    private void Awake()
    {
        seeker = GetComponent<Seeker>();
    }
    // Use this for initialization
    private void Start()
    {
        RecalculatePath();
    }

    public void RecalculatePath()
    {
        seeker.StartPath(transform.position, TargetDestination, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        isMoving = true;

        path = p;
        waypointList = p.vectorPath;
        if (waypointList.Count != 0) {
            NextWaypoint = waypointList[0];
        }
        Debug.Log(NextWaypoint);
        Debug.Log(waypointList.Count);
    }

    private void ReachWaypoint()
    {
        waypointCount++;
        Debug.Log(waypointCount);
        Debug.Log(waypointList);
        Debug.Log(waypointList.Count);
        NextWaypoint = waypointList[waypointCount];
        Debug.Log(NextWaypoint);
    }

    // Update is called once per frame
    private void Update()
    {
        if (isMoving) {
            Move();
        }
    }

    private void Move()
    {
        Vector3 f = (NextWaypoint - transform.position).normalized*MovementSpeed*Time.deltaTime;
        rigidbody2D.AddForce(f);
        if (HasReachedWaypoint()) {
            print("Reached");
            ReachWaypoint();
        }
    }

    private bool HasReachedWaypoint()
    {
        if (NextWaypoint != null && (NextWaypoint - transform.position).magnitude <= WaypointCheckRadius) {
            return true;
        }

        return false;
    }
}