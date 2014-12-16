using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public Apparatus App;

	public bool power = false;

	private float Health = 100;

	void Start () {
	
	}

	void Update () {
	
		if (App != null && power == true) {
			UpdateApparatus();
		}

	}

	public void PowerOn () {
		power = true;
	}
	
	public void PowerOff () {
		power = false;
	}

	public void Damage (float amount) {
		Health -= amount;
		if (Health <= 0) {
			Destroy(gameObject);
		}
	}

	public void SetApparatus (GameObject app) {
		App = app.GetComponent<Apparatus>();
		App.transform.position = transform.position;
	}

	void UpdateApparatus () {
		if (App.transform.position != transform.position) App.transform.position = transform.position;
		if (power) App.hasPower = true;
	}

}
