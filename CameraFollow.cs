using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ObjToFollow;
    public float LerpNum;
    public float yLevel;
    private void Update()
    {
        Vector3 ep = ObjToFollow.transform.position;
        ep.y = yLevel;
        this.transform.eulerAngles = new Vector3(90, 0, 0);
        this.transform.position = Vector3.Lerp(new Vector3(this.transform.position.x, yLevel, this.transform.position.z),ep,LerpNum);
    }
}
