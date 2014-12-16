using UnityEngine;
using System.Collections;

public class Apparatus : MonoBehaviour {

	public float TurnTime = 0.7f;
	public float Range = 20f;
	public float FireDelay = 0.5f;

	private float AimDir;
	public bool hasPower = false;

	private GameObject target;

	void Start () {
	
	}

	void Update () {

		if (hasPower) FindTarget();
		UpdateRotation();
		
	}

	void LateUpdate () {
		hasPower = false;
	}

	void FindTarget () {
		//Overlapsphere check for targets here
		//if no target in sight, return

		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // pos will be target.position

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

	void Fire () {

	}

}