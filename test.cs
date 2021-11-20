using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject gun;
    private void Awake()
    {
        this.GetComponent<InventoryFramework>().EquipGun(0);
        this.GetComponent<InventoryFramework>().EquipGun(1);
        this.GetComponent<InventoryFramework>().EquipGun(2);
        this.GetComponent<InventoryFramework>().EquipGun(3);
        this.GetComponent<InventoryFramework>().ChangeChosedSlot(0);
    }
}
