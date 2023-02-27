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
    public bool PlayerSpeedBuffed;
    public bool PlayerSpeedDebuffed;

    public PlayerData(int fishCollected=0, bool isSliding=false, bool isTeleporting = false, bool speedBuff = false, bool speedDebuff = false)
    {
        FishCollected = fishCollected;
        IsPlayerSliding = isSliding;
        IsPlayerTeleporting = isTeleporting;
        PlayerSpeedBuffed = speedBuff;
        PlayerSpeedDebuffed = speedDebuff;
    }
}
