using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePowerupFactory : MonoBehaviour
{
    //Resources will be used instead of setting prefabs
    public GameObject CreatePowerup(string type)
    {
        GameObject prefab;
        switch(type)
        {
            case "BaseFish":
                prefab = Resources.Load<GameObject>("BaseFish");
                break;
            case "SpeedFish":
                prefab = Resources.Load<GameObject>("SpeedFish");
                break;
            case "RandomPowerup":
                prefab = Resources.Load<GameObject>("RandomPowerup");
                break;
            default:
                throw new MissingComponentException();
        }
        return prefab;
    }

    public void AddPowerupScript(GameObject powerup, string type)
    {
        switch (type)
        {
            case "BaseFish":
                powerup.AddComponent<BaseFish>();
                break;
            case "SpeedFish":
                powerup.AddComponent<SpeedFish>();
                break;
            case "RandomPowerup":
                powerup.AddComponent<RandomPowerup>();
                break;
        }
    }
}
