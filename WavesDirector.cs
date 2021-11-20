using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesDirector : MonoBehaviour
{
    public GameObject[] Spawners;

    private int[,] SpawnersOnWaves = new int[,]
    {
        {1, 2, 3, -1, -1},
        {2, 4, 5, 1, -1},
        {1, 4, 5, -1, -1},
        {2, 3, 5, -1, -1},
        {1, 3, 4, 5, -1},
        {1, 2, 3, 4, 5}
    };
    
    public int Wave = 0;
    public int EnemiesOnWave = 5;
    public int EnemiesAmount = 0;
    public float PauseAfterWave = 15f;
    private float timeBeforeNextWave;

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
                timeBeforeNextWave = PauseAfterWave;
                if (Wave == 0)
                {
                    for (int i = 0; i < SpawnersOnWaves.GetLength(Wave); i++)
                    {
                        if (SpawnersOnWaves[Wave, i] != -1)
                            Spawners[i].GetComponent<Spawner>().CanSpawn = true;
                    }
                }
                else if (Wave < SpawnersOnWaves.Length)
                {
                    for (int i = 0; i < SpawnersOnWaves.GetLength(Wave); i++)
                    {
                        if (SpawnersOnWaves[Wave, i] != -1)
                            Spawners[i].GetComponent<Spawner>().CanSpawn = false;
                    }

                    Wave += 1;
                    for (int i = 0; i < SpawnersOnWaves.GetLength(Wave); i++)
                    {
                        if (SpawnersOnWaves[Wave, i] != -1)
                            Spawners[i].GetComponent<Spawner>().CanSpawn = true;
                    }

                    EnemiesOnWave = Convert.ToInt32(Math.Round(EnemiesOnWave * 1.2));
                }
                else
                {
                    for (int i = 0; i < Spawners.Length; i++)
                    {
                        Spawners[i].GetComponent<Spawner>().CanSpawn = true;
                    }
                }
            }

            timeBeforeNextWave -= Time.deltaTime;
        }
        else
        {
            if (EnemiesAmount >= EnemiesOnWave)
            {
                for (int i = 0; i < Spawners.Length; i++)
                {
                    Spawners[i].GetComponent<Spawner>().CanSpawn = false;
                }
            }
        }
    }
}