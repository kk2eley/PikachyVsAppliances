using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject cumi;
    private void Awake()
    {
        this.GetComponent<InventoryFramework>().EquipGunAtSlot(cumi, 1);
        this.GetComponent<InventoryFramework>().ChangeChosedSlot(1);
    }
}
