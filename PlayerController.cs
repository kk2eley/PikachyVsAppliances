using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool W, A, S, D;
    public float StudsPerSecond;
    public float movementLerp;
    public float rotationLerp;
    private Vector3 MoveVector;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            W = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            A = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            S = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            D = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            W = false;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            A = false;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            S = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            D = false;
        }
        if ((W && S) || (W == false && S == false))
        {
            if ((A && D) || (A == false && D == false))
            {
                MoveVector = Vector3.Lerp(MoveVector, new Vector3(0, 0, 0), movementLerp);
            }
            else if (A && D == false)
            {
                MoveVector = Vector3.Lerp(MoveVector, new Vector3(-1, 0, 0), movementLerp);
            }
            else
            {
                MoveVector = Vector3.Lerp(MoveVector, new Vector3(1, 0, 0), movementLerp);
            }
        }
        else if (W && S == false)
        {
            if ((A && D) || (A == false && D == false))
            {
                MoveVector = Vector3.Lerp(MoveVector, new Vector3(0, 0, 1), movementLerp);
            }
            else if (A && D == false)
            {
                MoveVector = Vector3.Lerp(MoveVector, new Vector3(-Mathf.Pow(2, 0.5f) / 2, 0, Mathf.Pow(2, 0.5f) / 2), movementLerp);
            }
            else
            {
                MoveVector = Vector3.Lerp(MoveVector, new Vector3(Mathf.Pow(2, 0.5f) / 2, 0, Mathf.Pow(2, 0.5f) / 2), movementLerp);
            }
        }
        else
        {
            if ((A && D) || (A == false && D == false))
            {
                MoveVector = Vector3.Lerp(MoveVector, new Vector3(0, 0, -1), movementLerp);
            }
            else if (A && D == false)
            {
                MoveVector = Vector3.Lerp(MoveVector, new Vector3(-Mathf.Pow(2, 0.5f) / 2, 0, -Mathf.Pow(2, 0.5f) / 2), movementLerp);
            }
            else
            {
                MoveVector = Vector3.Lerp(MoveVector, new Vector3(Mathf.Pow(2, 0.5f) / 2, 0, -Mathf.Pow(2, 0.5f) / 2), movementLerp);
            }
        }
        this.GetComponent<Rigidbody>().velocity = MoveVector * StudsPerSecond;
        Vector3 pp = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 mp = Input.mousePosition;
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, Mathf.Atan2(pp.x - mp.x, pp.y - mp.y) / Mathf.PI * 180, 0), rotationLerp);
    }
}
