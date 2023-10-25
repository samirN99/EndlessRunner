using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;

    [SerializeField] private Transform obstacleParent;
    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 1f;

    private float timeUntilObstacleSpawn;


    private void Start()
    {
        GameManager.Instance.onGameOver.AddListener(ClearObstacles);
    }



    private void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            SpawnLoop();
        }
    }


    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }

        
    }

    private void ClearObstacles()
    { 
    foreach(Transform child in obstacleParent)
        {
            Destroy(child.gameObject);
        }
    }


    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);  //will spawn in at the rotation the prefab is set to. Quaternion.identity means no rotation

        spawnedObstacle.transform.parent = obstacleParent;

        Rigidbody2D obstacleRb = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRb.velocity = Vector2.left * obstacleSpeed;
    }


}
