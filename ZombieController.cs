using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public GameObject Player;
    public int speed;
    public float attackDist;
    public float damage;
    public float DamageCooldown;
    private float damageTime;
    public int WaitUntilWave;
    public float SpawnChance;
    private void Update()
    {
        this.GetComponent<Rigidbody>().velocity = (Player.transform.position - this.transform.position).normalized * speed;
        if ((Player.transform.position - this.transform.position).magnitude <= attackDist&& damageTime <= 0)
        {
            damageTime = DamageCooldown;
            Player.GetComponent<HealthSystem>().GiveDamage(damage);
        }
        damageTime -= Time.deltaTime;
    }
}