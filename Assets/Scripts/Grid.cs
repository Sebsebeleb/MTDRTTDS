using UnityEngine;
using System.Collections;

public static class Grid {

	public static Vector2 Position (Vector2 vec) {
		Vector2 vect = new Vector2();
		vect.x = Mathf.Round (vec.x);
		vect.y = Mathf.Round (vec.y);
		return vect;
	}

}
