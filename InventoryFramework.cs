using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryFramework : MonoBehaviour
{
    private Dictionary<GameObject, Dictionary<string, float>> Weapons = new Dictionary<GameObject, Dictionary<string, float>> { };
    private GameObject[] SlotsLinks = new GameObject[5];
    private int ChosedSlot;
    public void EquipGunAtSlot(GameObject model,int slot)
    {
        var data = model.GetComponent<WeaponData>().GetData();
        if (SlotsLinks[slot] == null)
        {
            Weapons.Add(model, data);
        }
        else
        {
            Weapons[SlotsLinks[slot]] = data;
        }
        SlotsLinks[slot] = model;
    }
    public void DestroyGuns()
    {
        this.GetComponent<EquipGunsFramework>().DestroyWeldedModel();
        Weapons = new Dictionary<GameObject, Dictionary<string, float>> { };
    }
    public void ChangeChosedSlot(int newNum)
    {
        ChosedSlot = newNum;
        if (SlotsLinks[ChosedSlot] != null)
        {
            this.GetComponent<EquipGunsFramework>().WeldModel(Instantiate(SlotsLinks[ChosedSlot]));
        }
    }

}
