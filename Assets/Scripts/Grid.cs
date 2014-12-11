using UnityEngine;
using System.Collections;

public static class Grid
{
    public static int MapWidth = 50;
    public static int MapHeight = 100;

    public static LayerMask ObstacleLayer;

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

    /// <summary>
    /// Get the tower block game object at the specified world position, if it exists.
    /// </summary>
    /// <param name="pos"></param>
    /// <returns>Block</returns>
    public static GameObject GetBlockAtPosition(Vector2 pos)
    {
           
		GameObject block = Physics2D.OverlapPoint(pos, ObstacleLayer).gameObject;
        if (block.tag != "Block") {
            return null;
        }

        return block;
    }
}
