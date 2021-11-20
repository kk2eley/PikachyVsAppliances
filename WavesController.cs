using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : MonoBehaviour
{
    public int MaxZombies;
    public GameObject ZombiePrefub;
    private int ZombiesAmount = 0;

    public void KillZombie(GameObject zombie)
    {
        ZombiesAmount -= 1;
        Destroy(zombie);
    }

    private void Update()
    {
        if (ZombiesAmount < MaxZombies)
        {
            GameObject zombie = Instantiate(ZombiePrefub);
            zombie.GetComponent<ZombieController>().ObjectToFollow = 
                this.GetComponent<CameraFollow>().ObjToFollow;
            ZombiesAmount += 1;
        }
    }
}