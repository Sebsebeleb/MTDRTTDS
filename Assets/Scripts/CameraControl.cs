using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {

		KeyboardMove();
	
	}

	void KeyboardMove () {
		Vector3 vect = transform.position;
		if (Input.GetKey (KeyCode.A)) {
			vect.x -= 0.2f;
		}
		if (Input.GetKey (KeyCode.D)) {
			vect.x += 0.2f;
		}
		if (Input.GetKey (KeyCode.W)) {
			vect.y += 0.2f;
		}
		if (Input.GetKey (KeyCode.S)) {
			vect.y -= 0.2f;
		}
		transform.position = vect;
	}

}
