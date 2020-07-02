using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class SerializableEntitySpawner
{
    public float time;
    public bool isSpawned;
    public int spawnCount;
    public int maxSpawns;
    public SerializableEntitySpawner(EntitySpawner loadedSpawner)
    {
        time = loadedSpawner.time;
        isSpawned = loadedSpawner.isSpawned;
        spawnCount = loadedSpawner.spawnCount;
        
    }


}
