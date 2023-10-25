using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;

    [SerializeField] private Transform obstacleParent;
    public float obstacleSpawnTime = 3f;
    [Range(0, 1)] public float obstacleSpawnTimeFactor = 0.1f;
    public float obstacleSpeed = 4f;
    [Range(0, 1)] public float obstacleSpeedFactor = 0.2f;

    private float _obstacleSpawnTime;
    private float _obstacleSpeed;

    private float timeUntilObstacleSpawn;
    private float timeAlive;

   







    private void Start()
    {
        GameManager.Instance.onGameOver.AddListener(ClearObstacles);                     //this is going to clear the obstacles when player dies

        GameManager.Instance.onPlay.AddListener(ResetFactors);                           //this is going to restart the time when player dies


    }



    private void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            timeAlive += Time.deltaTime;

            CalculateFactors();

            SpawnLoop();
        }
    }


    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= _obstacleSpawnTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }

        
    }

    private void CalculateFactors ()
    {
        _obstacleSpawnTime = obstacleSpawnTime / Mathf.Pow(timeAlive, obstacleSpawnTimeFactor);     //this is going to increase the speed of the obstacles over time
        _obstacleSpeed = obstacleSpeed * Mathf.Pow(timeAlive, obstacleSpeedFactor);                 
    }

    private void ClearObstacles()
    { 
    foreach(Transform child in obstacleParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void ResetFactors()
    {
        timeAlive = 1f;
         _obstacleSpawnTime = obstacleSpawnTime;
         _obstacleSpeed = obstacleSpeed;

}
    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);  //will spawn in at the rotation the prefab is set to. Quaternion.identity means no rotation

        spawnedObstacle.transform.parent = obstacleParent;

        Rigidbody2D obstacleRb = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRb.velocity = Vector2.left * _obstacleSpeed;
    }


}
