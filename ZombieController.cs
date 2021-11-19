using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public GameObject ObjectToFollow;
    public int speed;

    private void Update()
    {
        this.GetComponent<Rigidbody>().velocity =
            (ObjectToFollow.transform.position - this.transform.position).normalized * speed;
    }
}