using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLootEntityScript : MonoBehaviour
{
    public float AmmoDropChance;
    public float BoostDropChance;
    public void Died()
    {
        int num = Random.Range(1, 100);
        if (AmmoDropChance >= BoostDropChance)
        {
            if (num <= BoostDropChance)
            {
                this.GetComponent<ZombieController>().Player.GetComponent<PlayerController>().SpawnPowerUp(this.transform.position);
            }
            else if (num > BoostDropChance && num <= AmmoDropChance+BoostDropChance)
            {
                this.GetComponent<ZombieController>().Player.GetComponent<InventoryFramework>().SpawnAmmo(this.transform.position);
            }
        }
        else
        {
            if (num <= AmmoDropChance)
            {
                this.GetComponent<ZombieController>().Player.GetComponent<InventoryFramework>().SpawnAmmo(this.transform.position);
            }
            else if (num > AmmoDropChance && num <= BoostDropChance+AmmoDropChance)
            {
                this.GetComponent<ZombieController>().Player.GetComponent<PlayerController>().SpawnPowerUp(this.transform.position);
            }
        }
    }
}
