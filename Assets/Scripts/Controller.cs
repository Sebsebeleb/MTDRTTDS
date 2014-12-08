using UnityEngine;
using System.Collections;
using Pathfinding;

public class Controller : MonoBehaviour {

	public GameObject TowerObj;
	public LayerMask TowerBlock;

	private SpriteRenderer renderer = new SpriteRenderer();

	private Vector2 mousePos = new Vector2();
	
	void Start () {
		renderer = GetComponent<SpriteRenderer>();
	}

	void Update () {

		GetMousePos();
		PreviewTower();

		if (Input.GetMouseButton (0)) {
			PlaceTower();
		}
	
	}

	/// <summary>
	/// Gets the mouse position in grid.
	/// </summary>
	void GetMousePos () {
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos = Grid.Position (mousePos);
	}

	/// <summary>
	/// Places the tower on mousePos.
	/// </summary>
	void PlaceTower () {
		Collider2D coll = Physics2D.OverlapPoint (mousePos, TowerBlock);
		if ( coll != null ) return;

		GameObject ins = Instantiate (TowerObj as Object) as GameObject;
		ins.transform.position = Grid.Position (mousePos);
	}

	/// <summary>
	/// Previews the tower on mousePos.
	/// Also checks if placement is possible (no colliding obstacle) and colors preview thereafter.
	/// </summary>
	void PreviewTower () {
		renderer.sprite = TowerObj.GetComponent<SpriteRenderer>().sprite;
		Collider2D coll = Physics2D.OverlapPoint (mousePos, TowerBlock);
		if ( coll == null ) {
			renderer.material.SetColor ("_Color", Color.green);
		}
		else {
			renderer.material.SetColor ("_Color", Color.red);
		}
		transform.position = mousePos;
	}

}

