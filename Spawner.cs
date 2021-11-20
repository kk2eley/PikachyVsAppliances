using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] PrefabEnemies;
    // public int EnemiesLimit = 10;
    // private int EnemiesAmount = 0;
    private Vector3 spawnerPosition;
    public float EnemySpawnDelay = 1f;
    private float curTime;
    public bool CanSpawn = false;
    private void Start()
    {
        curTime = EnemySpawnDelay;
        spawnerPosition = GetComponent<Transform>().position;
    }

    void Update()
    {
        if (CanSpawn == true)
        {
            if (curTime - Time.deltaTime <= 0)
            {
                int enemyIndex = Random.Range(0, PrefabEnemies.Length);
                GameObject enemy = Instantiate(PrefabEnemies[enemyIndex], spawnerPosition,
                    Quaternion.Euler(0, 0, 0));
                enemy.GetComponent<ZombieController>().Player =
                    Camera.main.GetComponent<CameraFollow>().ObjToFollow;
                Camera.main.GetComponent<WavesDirector>().EnemiesAmount += 1;
                // EnemiesAmount += 1;
                curTime = EnemySpawnDelay;
            }
            else
            {
                curTime -= Time.deltaTime;
            }
        }
    }
    public void DestroyEnemy(GameObject enemy)
    {
        // EnemiesAmount -= 1;
        Camera.main.GetComponent<WavesDirector>().EnemiesAmount -= 1;
        Destroy(enemy);
    }
}