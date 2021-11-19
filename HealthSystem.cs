using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public bool IsPlayer;
    public float Health;
    public float AddHealthPerSec;
    public void GiveDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            if (IsPlayer)
            {
                ////restart game
            }
            else
            {
                Camera.main.GetComponent<Spawner>().DestroyEnemy(this.gameObject);
            }
        }
    }
    private void Update()
    {
        if (Health > 0)
        {
            Health += AddHealthPerSec * Time.deltaTime;
        }
    }
}
