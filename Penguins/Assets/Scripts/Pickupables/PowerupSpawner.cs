using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    SimplePowerupFactory powerupFactory = new SimplePowerupFactory();
    private BoxCollider spawnArea;
    public LayerMask groundLayer;

    private void Awake()
    {
        spawnArea = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        SpawnPowerups();
    }

    private void SpawnPowerups()
    {
        for(int i=0; i<25;i++)
        {
            SpawnPowerup("BaseFish");
        }
        for(int i=0; i<15; i++)
        {
            SpawnPowerup("SpeedFish");
        }
        for(int i=0; i<10; i++)
        {
            SpawnPowerup("RandomPowerup");
        }
    }

    public void SpawnPowerup(string type)
    {
        GameObject powerup = powerupFactory.CreatePowerup(type);
        Vector3 spawnPoint = spawnArea.bounds.center + new Vector3(Random.Range(-spawnArea.bounds.extents.x, spawnArea.bounds.extents.x), 0, Random.Range(-spawnArea.bounds.extents.z, spawnArea.bounds.extents.z));
        RaycastHit hit;
        if (Physics.Raycast(spawnPoint, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            powerup = Instantiate(powerup, new Vector3(hit.point.x, hit.point.y + 1, hit.point.z), Quaternion.identity);
        }
        //powerup.SetActive(false);
        // Not using this allows for powerups to already have their scripts which in turn allows to edit the variables in unity editor
        //powerupFactory.AddPowerupScript(powerup, type);
        //powerup.SetActive(true);
    }
}
