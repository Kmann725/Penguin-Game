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

    protected virtual void OnTriggerEnter(Collider other)
    {
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        if(pc)
        {
            pickupable.Pickup(pc);
            pc.sources[0].volume = 0.7f;
            pc.sources[0].PlayOneShot(pc.eating);
            Destroy(gameObject);
        }
    }
}
