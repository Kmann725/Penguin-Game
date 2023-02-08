/*
 * Gerard Lamoureux
 * Pickup
 * Team Project 1
 * Class for Speed Fish Pickupables
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedFish : Pickup
{
    [SerializeField] private int amount = 2;
    private void Awake()
    {
        SetPickup(new SpeedPickup(amount));
    }
}
