using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    private LevelGenerator levelGenerator;

    public GameObject[] platformLayouts;
    public GameObject staticPlatform;
    private List<GameObject> randomPlatforms = new List<GameObject>();
    private PlatformSpawner[] spawners;

    public void Generate(LevelGenerator levelGenerator) {
        this.levelGenerator = levelGenerator;

        var platformId = Random.Range(0,platformLayouts.Length);
        platformLayouts[platformId].SetActive(true);

        for(var i = 0; i < platformLayouts.Length; i++) {
            if(i != platformId) {
                Destroy(platformLayouts[i]);
            }
        }

        spawners = transform.GetComponentsInChildren<PlatformSpawner>();

        foreach(var spawner in spawners) {
            bool isEnemySpawn = Random.Range(0,2) == 1;
            spawner.Spawn(isEnemySpawn ? levelGenerator.enemies : levelGenerator.powerups);
        }

        RaycastHit hit;
        
        for(var i = 0; i < Random.Range(0,3); i++) {
            if(Physics.Raycast(transform.position + new Vector3(Random.Range(-15f,15f), 20, 0), Vector3.down, out hit)) {
                var coinSpawn = Instantiate(levelGenerator.coin);
                var newPoint = hit.point;
                newPoint.y += 2;
                coinSpawn.transform.position = newPoint;       
            }
        }
    }
}
