using UnityEngine;
using System.Collections;

public static class Grid {

	public static Vector2 Position (float x, float y) {
		Vector2 vect = new Vector2();
		vect.x = Mathf.Round (x);
		vect.y = Mathf.Round (y);
		return vect;
	}

}
