using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryFramework : MonoBehaviour
{
    public GameObject[] allWeapons;
    private Dictionary<int, Dictionary<string, float>> Weapons = new Dictionary<int, Dictionary<string, float>> { };
    private Dictionary<GameObject,int> AmmoBoxes = new Dictionary<GameObject, int> { };
    private int ChosedSlot = 0;
    public float MaxDistToPickUpAmmo;
    private bool LMouseDown = false;
    public void EquipGun(int num)
    {
        var data = allWeapons[num].GetComponent<WeaponData>().GetData();
        data["FIRERATE_COOLDOWN"] = 0;
        data["AMMO"] = data["AMMO_ADD"];
        if (Weapons.ContainsKey(num))
        {
            Weapons.Add(num, data);
        }
        else
        {
            Weapons[num] = data;
        }
    }
    public void DestroyGuns()
    {
        this.GetComponent<EquipGunsFramework>().DestroyWeldedModel();
        //AmmoBoxes = new Dictionary<Vector3, GameObject> { };
        Weapons = new Dictionary<int, Dictionary<string, float>> { };
    }
    public void ChangeChosedSlot(int newNum)
    {
        if (Weapons.ContainsKey(newNum))
        {
            ChosedSlot = newNum;
            this.GetComponent<EquipGunsFramework>().WeldModel(Instantiate(allWeapons[newNum]));
        }
    }
    private void Update()
    {
        {
            List<GameObject> toDestroy = new List<GameObject> { };
            foreach (GameObject key in AmmoBoxes.Keys)
            {
                if ((new Vector2(key.transform.position.x, key.transform.position.z) - new Vector2(this.transform.position.x, this.transform.position.z)).magnitude <= MaxDistToPickUpAmmo)
                {
                    if (Weapons.ContainsKey(AmmoBoxes[key]))
                    {
                        Weapons[AmmoBoxes[key]]["AMMO"] += Weapons[AmmoBoxes[key]]["AMMO_ADD"];
                    }
                    else
                    {
                        EquipGun(AmmoBoxes[key]);
                    }
                    toDestroy.Add(key);
                }
            }
            foreach (GameObject key in toDestroy)
            {
                AmmoBoxes.Remove(key);
                Destroy(key);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            LMouseDown = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            LMouseDown = false;
        }
        if (Weapons.ContainsKey(ChosedSlot) && Weapons[ChosedSlot]["FIRERATE_COOLDOWN"]<= 0 && Weapons[ChosedSlot]["AMMO"] > 0 && LMouseDown)
        {
            var data = Weapons[ChosedSlot];
            data["AMMO"] -= 1;
            for (int i = 1; i <= data["BULLETS_PER_SHOT"]; i += 1)
            {
                float x = -Mathf.Sin((this.transform.eulerAngles.y + Random.Range(-data["ANGLES_SPREAD"] / 2, data["ANGLES_SPREAD"] / 2)) / 180 * Mathf.PI);
                float z = -Mathf.Cos((this.transform.eulerAngles.y + Random.Range(-data["ANGLES_SPREAD"] / 2, data["ANGLES_SPREAD"] / 2)) / 180 * Mathf.PI);
                data["FIRERATE_COOLDOWN"] = data["FIRERATE"];
                Camera.main.GetComponent<BulletsFramework>().Fire(
                    this.transform.position,
                    new Vector3(x, 0, z),
                    data["BULLET_RANGE"],
                    data["DAMAGE"],
                    data["BULLET_TYPE"],
                    data["MAX_EXPLODE_DIST"]);
            }
        }
        foreach(int key in Weapons.Keys)
        {
            Weapons[key]["FIRERATE_COOLDOWN"] -= Time.deltaTime;
        }
    }
    public void SpawnAmmo(Vector3 pos)
    {
        int num = Random.Range(1, allWeapons.Length);
        GameObject obj = Instantiate(allWeapons[num].GetComponent<WeaponData>().AMMO_MODEL);
        obj.transform.position = pos;
        AmmoBoxes.Add(obj, num);
    }
}
