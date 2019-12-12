using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public void Spawn(GameObject[] spawnArray) {
        var spawnItem = spawnArray[Random.Range(0, spawnArray.Length)];
        var spawned = Instantiate(spawnItem);
        spawned.transform.position = spawnPoint.position;
    }
}
