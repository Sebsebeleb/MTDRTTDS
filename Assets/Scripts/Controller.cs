using UnityEngine;
using System.Collections;
using Pathfinding;

public class Controller : MonoBehaviour {

	public AstarPath TileMap;

	public GameObject TowerObj;
	public LayerMask TowerBlock;

	public bool Placing = false;
	
	public Sprite SelectionSprite;
	public GameObject Selected;

	private SpriteRenderer mainRender = new SpriteRenderer();

	private Vector2 mousePos = new Vector2();
	private Collider2D coll;
	
	void Start () {
		mainRender = GetComponent<SpriteRenderer>();
		SetTower(TowerObj); //REMOVE ME LATER
	}

	void Update () {

		GetMousePos();

		if (Placing) {
			PreviewTower();

			if (Input.GetMouseButton (0)) {
				PlaceTower();
			}

			if (Input.GetMouseButton (1)) {
				Placing = false;
				mainRender.sprite = null;

			}
		}
		else {
			if (Input.GetMouseButton (0)) {
				GetTower();
			}
		}
	
	}

	/// <summary>
	/// Gets the mouse position in grid.
	/// Also Overlap-checks position and saves colliders to "coll".
	/// </summary>
	void GetMousePos () {
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos = Grid.Position (mousePos);
		coll = Physics2D.OverlapPoint (mousePos, TowerBlock);
	}

	/// <summary>
	/// Places the tower on mousePos.
	/// </summary>
	void PlaceTower () {

		if ( coll != null ) return;

		GameObject ins = Instantiate (TowerObj as Object) as GameObject;
		ins.transform.position = Grid.Position (mousePos);
        ins.BroadcastMessage("OnBuilt");

		TileMap.Scan();
	}

	/// <summary>
	/// Previews the tower on mousePos.
	/// </summary>
	void PreviewTower () {
		if ( coll == null ) {
			mainRender.material.SetColor ("_Color", Color.green);
		}
		else {
			mainRender.material.SetColor ("_Color", Color.red);
		}
		transform.position = mousePos;
	}

	/// <summary>
	/// Set the current tower object and other related variables.
	/// </summary>
	/// <param name="obj">Tower.</param>
	void SetTower (GameObject obj) {
		TowerObj = obj;
		mainRender.sprite = TowerObj.GetComponent<SpriteRenderer>().sprite;
		Placing = true;
	}

	/// <summary>
	/// Saves ID of object in "coll".
	/// Also sets "Selected" to null if no object is found.
	/// </summary>
	void GetTower () {
		if (coll != null) {
			Selected = coll.gameObject;
			mainRender.material.SetColor ("_Color", Color.white);
			mainRender.sprite = SelectionSprite;
			transform.position = mousePos;
		}
		else {
			Selected = null;
			mainRender.sprite = null;
		}
	}

}

