using UnityEngine;
using System.Collections;

public class Apparatus : MonoBehaviour {

	public float TurnTime = 0.7f;
	public float Range = 20f;
	public float FireDelay = 0.5f;
    public GameObject BulletPrefab;

	private float AimDir;
	public bool hasPower = false;

	private GameObject target;
    private Targeting targeting;

    private float fireCounter;

    void Awake()
    {
        targeting = GetComponent<Targeting>();
    }

	void Start () {
	
	}

	void Update () {

	    if (!hasPower) {
	        return;
	    }

        FindTarget();
		UpdateRotation();
	    UpdateShooting();
	}

    /// <summary>
    /// Handles fire rate
    /// </summary>
    private void UpdateShooting()
    {
        fireCounter -= Time.deltaTime;

        if (target && fireCounter <= 0f) {
            Fire();
            fireCounter = FireDelay;
        }
    }

	void FindTarget ()
	{
		//if no target in sight, return
	    target = targeting.GetCurrentTarget();
	    if (!target) {
	        return;
	    }

	    Vector3 pos = target.transform.position;

		if (Vector3.Distance (transform.position, pos) < Range) {
			float deltaX = pos.x - transform.position.x;
			float deltaY = pos.y - transform.position.y;
			float angle = Mathf.Atan2 (deltaY, deltaX) * 180 / Mathf.PI;
			AimDir = angle + 90;
		}
	}

	void UpdateRotation () {
		iTween.RotateUpdate(gameObject, iTween.Hash ("rotation", new Vector3(0f, 0f, AimDir), "time", TurnTime));
	}

	void Fire ()
	{
	    GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;
	    BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
	    bulletBehaviour.Target = target;
	}

}