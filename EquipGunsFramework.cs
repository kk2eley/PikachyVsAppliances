using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipGunsFramework : MonoBehaviour
{
    private GameObject weldedModel;
    public void WeldModel(GameObject model)
    {
        if (weldedModel != null)
        {
            Destroy(weldedModel);
        }
        weldedModel = model;
    }
    public void DestroyWeldedModel()
    {
        Destroy(weldedModel);
    }
    private void Update()
    {
        if (weldedModel != null)
        {
            weldedModel.transform.position = this.transform.position;
            weldedModel.transform.rotation = this.transform.rotation;
        }
    }
}
