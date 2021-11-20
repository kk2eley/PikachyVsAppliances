using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public bool IsPlayer;
    public float Health;
    public float MaxHealth;
    public bool InfHealth;
    public float AddHealthPerSec;
    private bool AlreadyDied = false;
    public void GiveDamage(float damage)
    {
        if (InfHealth == false)
        {
            Health -= damage;
            if (Health <= 0 && AlreadyDied == false)
            {
                if (IsPlayer)
                {
                    ////restart game
                }
                else
                {
                    AlreadyDied = true;

                    this.GetComponent<DropLootEntityScript>().Died();
                    Camera.main.GetComponent<WavesController>().KillZombie(this.gameObject);
                }
            }
        }
    }
    private void Update()
    {
        if (Health > 0)
        {
            Health = Mathf.Min(MaxHealth,Health + AddHealthPerSec * Time.deltaTime);
        }
        else
        {
            GiveDamage(0);
        }
    }
}
