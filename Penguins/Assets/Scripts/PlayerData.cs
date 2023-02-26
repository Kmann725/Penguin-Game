/*
 * Gerard Lamoureux
 * PlayerData
 * Team Project 1
 * Handles PlayerData to be sent for Observers
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int FishCollected;
    public bool IsPlayerSliding;
    public bool IsPlayerTeleporting;

    public PlayerData(int fishCollected=0, bool isSliding=false, bool isTeleporting = false)
    {
        FishCollected = fishCollected;
        IsPlayerSliding = isSliding;
        IsPlayerTeleporting = isTeleporting;
    }
}
