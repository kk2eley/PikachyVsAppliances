using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : MonoBehaviour
{
    public int MaxZombies;
    public GameObject[] ZombiesPrefub;
    public GameObject[] Spawners;
    private int ZombiesAmount = 0;
    int WaveNum = 0;
    private void Awake()
    {
        float fullChance = 0;
        Dictionary<GameObject, float> zombs = new Dictionary<GameObject, float> { };
        foreach (GameObject key in ZombiesPrefub)
        {
            if (key.GetComponent<ZombieController>().WaitUntilWave > WaveNum)
            {
                fullChance += key.GetComponent<ZombieController>().SpawnChance;
                zombs.Add(key, key.GetComponent<ZombieController>().SpawnChance);
            }
        }
        foreach (GameObject key in zombs.Keys)
        {
            zombs[key] /= fullChance / 100;
        }
        foreach (GameObject key in zombs.Keys)
        {
            zombs[key] /= fullChance / 100;
        }
    }
    public void KillZombie(GameObject zombie)
    {
        ZombiesAmount -= 1;
        Destroy(zombie);
    }

    private void Update()
    {
        
            //GameObject zombie = Instantiate(ZombiesPrefub);
            //zombie.GetComponent<ZombieController>().Player = this.GetComponent<CameraFollow>().ObjToFollow;
           // ZombiesAmount += 1;
        
    }
}