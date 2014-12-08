using UnityEngine;
using System.Collections;

public static class Grid {

	/// <summary>
	/// Round a Vector2.
	/// </summary>
	/// <param name="vec">Vector2.</param>
	public static Vector2 Position (Vector2 vec) {
		Vector2 vect = new Vector2();
		vect.x = Mathf.Round (vec.x);
		vect.y = Mathf.Round (vec.y);
		return vect;
	}

}
