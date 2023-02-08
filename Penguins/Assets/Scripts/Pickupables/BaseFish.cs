/*
 * Gerard Lamoureux
 * Pickup
 * Team Project 1
 * Class for Speed Fish Pickupables
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFish : Pickup
{
    private void Awake()
    {
        SetPickup(new BasePickup());
    }
}
