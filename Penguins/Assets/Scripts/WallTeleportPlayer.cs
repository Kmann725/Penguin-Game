using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTeleportPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerController player))
        {
            player.TeleportToSpawn();
        }
    }
}
