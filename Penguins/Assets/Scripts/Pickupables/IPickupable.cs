/*
 * Gerard Lamoureux
 * Pickup
 * Team Project 1
 * Pickupable Interface
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    void Pickup(PlayerController pc);
}

public class BasePickup : IPickupable
{
    public void Pickup(PlayerController pc)
    {
        pc.FishCollected++;
        pc.NotifyPlayerObservers();
    }
}

public class SpeedPickup : IPickupable
{
    private int amount;
    public SpeedPickup(int amount = 2)
    {
        this.amount = amount;
    }
    public void Pickup(PlayerController pc)
    {
        pc.FishCollected++;
        pc.playerSpeedBuffed = true;
        //pc.UpdateSpeed(amount) function in PlayerController to update the player's speed multiplier
        //this.GameManager.GameManager.FishCount++;
        pc.NotifyPlayerObservers();
    }
}

public class TempSpeedBuffPickup : IPickupable
{
    private int amount;
    public TempSpeedBuffPickup(int amount = 10)
    {
        this.amount = amount;
    }
    public void Pickup(PlayerController pc)
    {
        pc.playerSpeedBuffed = true;
        pc.NotifyPlayerObservers();
    }
}

/// <summary>
/// Will Slow Player Down
/// </summary>
public class TempSpeedDebuffPickup : IPickupable
{
    private int amount;
    public TempSpeedDebuffPickup(int amount = 10)
    {
        this.amount = amount;
    }
    public void Pickup(PlayerController pc)
    {
        pc.playerSpeedDebuffed = true;
        pc.NotifyPlayerObservers();
    }
}

/// <summary>
/// Will Remove Fish Player Currently Has
/// </summary>
public class StarvingPickup : IPickupable
{
    public void Pickup(PlayerController pc)
    {
        if (pc.FishCollected > 0)
        {
            pc.FishCollected--;
            pc.NotifyPlayerObservers();
        }
    }
}
