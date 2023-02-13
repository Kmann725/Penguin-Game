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
        //this.GameManager.GameManager.FishCount++;
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
        //pc.UpdateSpeed(amount) function in PlayerController to update the player's speed multiplier
        //this.GameManager.GameManager.FishCount++;
        pc.NotifyPlayerObservers();
    }
}
