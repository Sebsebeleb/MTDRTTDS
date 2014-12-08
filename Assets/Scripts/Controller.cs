using UnityEngine;
using System.Collections;
using Pathfinding;

public class Controller : MonoBehaviour {

	public GameObject TowerObj;
	public LayerMask TowerBlock;
	
	void Start () {
	
	}

	void Update () {

		if (Input.GetMouseButton (0)) {
			PlaceTower();
		}
	
	}

	void PlaceTower () {
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos = Grid.Position (mousePos);
		Collider2D col = Physics2D.OverlapPoint (mousePos, TowerBlock);
		if ( col != null ) return;

		GameObject ins = Instantiate (TowerObj as Object) as GameObject;
		ins.transform.position = Grid.Position (mousePos);
	}

}

