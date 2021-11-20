using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool W, A, S, D;
    public float Speed;
    public float movementLerp;
    public GameObject[] prefubPowerUps;
    public float rotationLerp;
    private Vector3 MoveVector;
    public float MaxDistToPickUpPowerUp;
    private float SpeedAdd = 0;
    private List<Dictionary<string, float>> SpeedUps = new List<Dictionary<string, float>> { };
    private float InfHealthTime = 0;
    private List<GameObject> PowerUps = new List<GameObject> { };
    private void Update()
    {
        {
            List<GameObject> toDestroy = new List<GameObject> { };
            foreach (GameObject key in PowerUps)
            {
                if ((this.transform.position - key.transform.position).magnitude <= MaxDistToPickUpPowerUp)
                {
                    toDestroy.Add(key);
                    var data = key.GetComponent<PowerUpData>().GetData();
                    if (data["SPEED_ADD"] != 0)
                    {
                        var spedUp = new Dictionary<string, float> { };
                        spedUp["SPEED_ADD"] = data["SPEED_ADD"];
                        spedUp["EFFECT_LENGTH"] = data["EFFECT_LENGTH"];
                        SpeedUps.Add(spedUp);
                    }
                    if (data["INF_HEALTH"] == 1)
                    {
                        InfHealthTime = Mathf.Max(0, InfHealthTime) + data["EFFECT_LENGTH"];
                    }
                }
            }
            foreach (GameObject key in toDestroy)
            {
                PowerUps.Remove(key);
                Destroy(key);
            }
        }
        W = Input.GetKey(KeyCode.W);
        A = Input.GetKey(KeyCode.A);
        S = Input.GetKey(KeyCode.S);
        D = Input.GetKey(KeyCode.D);
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
        SpeedAdd = 0;
        {
            List<Dictionary<string, float>> toDestroy = new List<Dictionary<string, float>> { };
            foreach (var key in SpeedUps)
            {
                key["EFFECT_LENGTH"] -= Time.deltaTime;
                if (key["EFFECT_LENGTH"] > 0)
                {
                    SpeedAdd += key["SPEED_ADD"];
                }
                else
                {
                    toDestroy.Add(key);
                }
            }
            foreach (Dictionary<string, float> key in toDestroy)
            {
                SpeedUps.Remove(key);
            }
        }
        this.GetComponent<Rigidbody>().velocity = MoveVector * (Speed+SpeedAdd);
        Vector3 pp = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 mp = Input.mousePosition;
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, Mathf.Atan2(pp.x - mp.x, pp.y - mp.y) / Mathf.PI * 180, 0), rotationLerp);

        this.GetComponent<HealthSystem>().InfHealth = InfHealthTime > 0;
        InfHealthTime -= Time.deltaTime;
    }
    public void SpawnPowerUp(Vector3 pos)
    {
        int rand = Random.Range(0, prefubPowerUps.Length);
        print(prefubPowerUps[rand]);
        GameObject obj = Instantiate(prefubPowerUps[rand]);
        obj.transform.position = pos;
        PowerUps.Add(obj);
    }
}
