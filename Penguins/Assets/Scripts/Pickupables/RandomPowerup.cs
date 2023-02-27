using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerup : Pickup
{
    private void Awake()
    {
        SetPickup(new BasePickup());
    }

    private void Start()
    {
        StartCoroutine(UpdatePowerup());
    }

    IEnumerator UpdatePowerup()
    {
        List<string> list = new List<string> { "SpeedBuff", "SpeedDebuff", "FishDelete" };
        while(true)
        {
            string type = list[Random.Range(0, list.Count)];
            switch(type)
            {
                case "SpeedBuff":
                    SetPickup(new TempSpeedBuffPickup());
                    break;
                case "SpeedDebuff":
                    SetPickup(new TempSpeedDebuffPickup());
                    break;
                case "FishDelete":
                    SetPickup(new StarvingPickup());
                    break;
            }
            yield return new WaitForSeconds(Random.Range(15, 90));
        }
    }
}
