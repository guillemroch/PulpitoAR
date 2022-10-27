using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject platforms;
    [SerializeField] private float numOfPlatforms;
    [SerializeField] private float levelWidth = 3f;
    [SerializeField] private float minY = .2f;
    [SerializeField] private float maxY = 1.5f;

    public void generateLevel()
    {
        Vector3 spawnPosition = transform.position;


        var platform0 = Instantiate(platformPrefab, new Vector3(1.6789f, 1.0822f, 2.3871f), Quaternion.identity);
        platform0.transform.parent = platforms.transform;
        platform0.layer = platforms.layer;

        for (int i = 0; i < numOfPlatforms; i++){
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(transform.position[0]-levelWidth, transform.position[0]+levelWidth);
            var platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            platform.transform.parent = platforms.transform;
            platform.layer = platforms.layer;
        }
    }

    

}
