/*
 * Gerard Lamoureux
 * Pickup
 * Team Project 1
 * Base Pickup Class
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    IPickupable pickupable;

    public void SetPickup(IPickupable pickupable) { this.pickupable = pickupable; }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        if(pc)
        {
            pickupable.Pickup(pc);
            Destroy(gameObject);
        }
    }
}
