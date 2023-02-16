using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int FishCollected;
    public bool IsPlayerSliding;

    public PlayerData(int i=0, bool b=false)
    {
        FishCollected = i;
        IsPlayerSliding = b;
    }
}
