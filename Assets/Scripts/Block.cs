using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public bool PowerOn = false;

	private float Health = 100;

	void Start () {
	
	}

	void Update () {
	
	}

	void Damage (float amount) {
		Health -= amount;
		if (Health <= 0) {
			Destroy(gameObject);
		}
	}

}
