using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesDirector : MonoBehaviour
{
    public GameObject[] Spawners;

    private readonly int[,] SpawnersOnWaves = new int[,]
    {
        //Размер подмассива должен быть равен количеству спавнеров
        {-1, 1, 2, 3, -1, -1},
        {2, 4, 5, 1, -1, -1},
        {1, 4, 5, -1, -1, -1},
        {2, 3, 5, -1, -1, -1},
        {1, 3, 4, 5, -1, -1},
        {0, 1, 2, 3, 4, 5}
    };

    public int Wave = 0;
    private int nextWave = 0;
    public int EnemiesOnWave = 5;
    public int SpawnedEnemies = 0;
    public int EnemiesAmount = 0;
    public float PauseAfterWave = 15f;
    private float timeBeforeNextWave = 0;
    public float Difficulty = 1.2f;

    void Start()
    {
        // timeBeforeNextWave = PauseAfterWave;
    }

    void Update()
    {
        if (EnemiesAmount <= 0)
        {
            if (timeBeforeNextWave <= 0)
            {
                if (Wave == 0)
                {
                    if (nextWave == Wave)
                    {
                        for (int i = 0; i < SpawnersOnWaves.GetLength(Wave); i++)
                        {
                            if (SpawnersOnWaves[Wave, i] != -1)
                                Spawners[i].GetComponent<Spawner>().CanSpawn = true;
                            nextWave += 1;
                        }
                    }
                    else
                    {
                        nextWave += 1;
                        timeBeforeNextWave = PauseAfterWave;
                        EnemiesOnWave = Convert.ToInt32(Math.Round(EnemiesOnWave * Difficulty));
                    }
                }
                else if (Wave < SpawnersOnWaves.Length)
                {
                    if (nextWave == Wave)
                    {
                        timeBeforeNextWave = PauseAfterWave;
                        for (int i = 0; i < SpawnersOnWaves.GetLength(Wave); i++)
                        {
                            if (SpawnersOnWaves[Wave, i] != -1)
                                Spawners[i].GetComponent<Spawner>().CanSpawn = false;
                        }

                        for (int i = 0; i < SpawnersOnWaves.GetLength(Wave + 1); i++)
                        {
                            if (SpawnersOnWaves[Wave, i] != -1)
                                Spawners[i].GetComponent<Spawner>().CanSpawn = true;
                        }

                        nextWave += 1;
                        
                    }
                    else
                    {
                        nextWave += 1;
                        timeBeforeNextWave = PauseAfterWave;
                        EnemiesOnWave = Convert.ToInt32(Math.Round(EnemiesOnWave * Difficulty));
                    }
                }
                else
                {
                    if (nextWave == Wave)
                    {
                        for (int i = 0; i < Spawners.Length; i++)
                        {
                            Spawners[i].GetComponent<Spawner>().CanSpawn = true;
                        }
                    }
                    else
                    {
                        nextWave += 1;
                        timeBeforeNextWave = PauseAfterWave;
                        EnemiesOnWave = Convert.ToInt32(Math.Round(EnemiesOnWave * Difficulty));
                    }
                }
            }

            timeBeforeNextWave -= Time.deltaTime;
        }
        else
        {
            if (SpawnedEnemies >= EnemiesOnWave)
            {
                for (int i = 0; i < Spawners.Length; i++)
                {
                    Spawners[i].GetComponent<Spawner>().CanSpawn = false;
                }
            }
        }
    }
}