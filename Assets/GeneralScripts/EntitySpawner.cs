using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public GameObject entity;
    public float time;
    public bool isSpawned;
    public float spawnTime;
    public float spawnRadius;
    public Vector3 spawnOffset;
    public int spawnCount;
    public int maxSpawns;
    

    public void Update()
    {
        if (isSpawned)
        {
            return;
        }
        if (time > spawnTime)
        {
            if ((spawnCount + 1 >= maxSpawns) && (maxSpawns > 0))
            {
                this.gameObject.SetActive(false);
                return;
            }
            SpawnEntity();
            isSpawned = true;
            time = 0;
            spawnCount++;
            return;
        }
        time+=Time.deltaTime;


    }

    public void UpdateSpawnerFromLoad(SerializableEntitySpawner loadedSpawner)
    {
        time = loadedSpawner.time;
        isSpawned = loadedSpawner.isSpawned;
        spawnCount = loadedSpawner.spawnCount; 
    }

    private void SpawnEntity()
    {
        var component = entity.GetComponent<NPC>();
        if (component != null)
        {
            entity.SetActive(true);
            component.state = 1;
           component.currentHealth = component.maxHealth;
            entity.transform.SetPositionAndRotation(component.spawnLocation, entity.transform.rotation);

        }
            
    }

}
