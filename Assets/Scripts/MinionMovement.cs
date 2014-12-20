using Pathfinding;
using UnityEngine;
using System.Collections;

public class MinionMovement : MonoBehaviour
{

    private Seeker seeker;

    void Awake()
    {
        seeker = GetComponent<Seeker>();
    }

    void Start()
    {
        
    }

    public void UpdatePath()
    {
        Debug.Log("Hello start updatepath");
        Vector3 targetPos = new Vector3(Random.Range(5f, 5f), Random.Range(5f, 5f));
        Seeker sk = GetComponent<Seeker>();
        sk.StartPath(transform.position, targetPos, OnPathCalculated);
    }

    public void OnPathCalculated(Path p)
    {
        Debug.Log("Hello, got path");
    }

}
