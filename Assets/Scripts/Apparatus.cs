using UnityEngine;
using System.Collections;

public class Apparatus : MonoBehaviour {
	
	public float TurnTime = 0.7f;

	public float AimDir;

	void Start () {
	
	}

	void Update () {



		iTween.RotateUpdate(gameObject, iTween.Hash ("rotation", new Vector3(0f, 0f, AimDir), "time", TurnTime));
	
	}
}
