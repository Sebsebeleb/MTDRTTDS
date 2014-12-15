using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(Seeker))]
public class EnemyMove : MonoBehaviour
{
    public Vector3 TargetDestination;
    private Vector3 NextWaypoint;

    public float WaypointCheckRadius = 0.2f;
    public float MovementSpeed = 0.4f;

    protected Seeker seeker;
    private Path path;
    private List<Vector3> waypointList = new List<Vector3>();
    private int waypointCount = 0;
    private bool isMoving;
    private bool startHasRun = false;

    protected virtual void Awake()
    {
        seeker = GetComponent<Seeker>();
    }

    // Use this for initialization
    private void Start()
    {
        startHasRun = true;
        OnEnable();
    }

    protected virtual void OnEnable()
    {
        if (startHasRun) {
            seeker.pathCallback += OnPathComplete;
            RecalculatePath();
        }
    }

    public void OnDisable()
    {
        // Abort calculation of path
        if (seeker != null && !seeker.IsDone()) seeker.GetCurrentPath().Error();

        // Release current path
        if (path != null) path.Release(this);
        path = null;

        //Make sure we receive callbacks when paths complete
        seeker.pathCallback -= OnPathComplete;
    }

    public void RecalculatePath()
    {
        seeker.StartPath(transform.position, TargetDestination);
    }

    public virtual void OnPathComplete(Path p)
    {
        isMoving = true;

        path = p;
        waypointList = p.vectorPath;
        if (waypointList.Count != 0) {
            NextWaypoint = waypointList[0];
        }
    }

    private void ReachWaypoint()
    {
        waypointCount++;
        NextWaypoint = waypointList[waypointCount];
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