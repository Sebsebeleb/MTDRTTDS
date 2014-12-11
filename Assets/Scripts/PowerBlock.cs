using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PowerBlock : MonoBehaviour
{
    public bool IsPowered = false; // Must have a connection back to the main base in order to be powered

    /// <summary>
    /// Should be called when it has been spawned.
    /// </summary>
    public void OnBuilt()
    {
        List<PowerBlock> adjacentBlocks = PowerManager.GetAdjacentPower(transform.position);

        //Check if any of them are already powered to see if this should be powered by them
        foreach (PowerBlock power in adjacentBlocks) {
            if (power.IsPowered) {
                SetPoweredOn();
                break;
            }
        }
        
        GameObject block = Grid.GetBlockAtPosition(transform.position);
        if (!block) {
            return;
        }
        
        block.BroadcastMessage("PowerOn");

        //If we have power, turn on nearby power blocks
        if (IsPowered) {
            foreach (PowerBlock power in adjacentBlocks) {
                power.IsPowered = true;
            }           
        }           
    }

    public void SetPoweredOn()
    {
        IsPowered = true;

        // Power on all nearby power blocks
        List<PowerBlock> adjacentBlocks = PowerManager.GetAdjacentPower(transform.position);
        foreach (PowerBlock power in adjacentBlocks) {
            if (power.IsPowered) {
                power.SetPoweredOn();
            }
        }
    }

    public void SetPoweredOff()
    {
        IsPowered = true;

        // Power on all nearby power blocks
        List<PowerBlock> adjacentBlocks = PowerManager.GetAdjacentPower(transform.position);
        foreach (PowerBlock power in adjacentBlocks) {
            if (power.IsPowered) {
                power.SetPoweredOff();
            }
        }
    }

    public void Destroy()
    {
        SetPoweredOff();
    }
}