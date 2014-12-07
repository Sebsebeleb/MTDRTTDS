using UnityEngine;
using System.Collections;

public class TestCube : MonoBehaviour {

	void Start () {
		transform.position = Grid.Position (transform.position.x, transform.position.y);
	}

	void Update () {
	
	}
}
