using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.GetComponent<InventoryFramework>().ChangeChosedSlot(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.GetComponent<InventoryFramework>().ChangeChosedSlot(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.GetComponent<InventoryFramework>().ChangeChosedSlot(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            this.GetComponent<InventoryFramework>().ChangeChosedSlot(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            this.GetComponent<InventoryFramework>().ChangeChosedSlot(5);
        }
    }
}
