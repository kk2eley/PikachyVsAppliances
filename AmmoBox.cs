using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    void Update()
    {
        this.transform.eulerAngles += new Vector3(0, 1, 0);
        this.transform.position = new Vector3(this.transform.position.x, Mathf.Sin(Time.time * 5) / 4, this.transform.position.z);
    }
}
