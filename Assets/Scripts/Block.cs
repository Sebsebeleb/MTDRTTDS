using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	private bool power = false;

	private float Health = 100;

	void Start () {
	
	}

	void Update () {
	
	}

	void PowerOn () {
		power = true;
	}
	
	void PowerOff () {
		power = false;
	}

	void Damage (float amount) {
		Health -= amount;
		if (Health <= 0) {
			Destroy(gameObject);
		}
	}

}
