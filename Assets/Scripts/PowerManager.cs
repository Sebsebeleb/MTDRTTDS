using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PowerManager
{

    private static PowerBlock[,] powerBlocks;

	// Use this for initialization

    public static PowerBlock GetPowerAt(Vector2 worldPos)
    {
        if (isOutOfBounds(worldPos)) {
            return null;
        }
        return powerBlocks[(int) worldPos.x, (int) worldPos.y];
    }

    /// <summary>
    /// Returns all power blocks adjecent to the specified position
    /// </summary>
    /// <param name="worldPos"></param>
    /// <returns>List of PowerBlocks adjecent to the specified position</returns>
    public static List<PowerBlock> GetAdjacentPower(Vector2 worldPos)
    {
        List<PowerBlock> ret = new List<PowerBlock>();

        Vector2[] directions = {new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1)};

        foreach (Vector2 d in directions) {
            Vector2 pos = worldPos + d;
            if (!isOutOfBounds(pos)) {
                PowerBlock pb = GetPowerAt(pos);
                if (pb != null) {
                    ret.Add(pb);
                }
            }
        }

        return ret;
    }

    /// <summary>
    /// Is the given position a valid position for the grid?
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private static bool isOutOfBounds(Vector2 pos)
    {
        if (pos.x > Grid.MapWidth || pos.x < 0) {
            return true;
        }

        if (pos.y > Grid.MapHeight || pos.y < 0) {
            return true;
        }

        return false;
    }
}
