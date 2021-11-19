using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    [Tooltip("ƒамаг")]
    public float DAMAGE;
    [Tooltip("“емп стрельбы по типу если написано 0.5 то каждую половину секунды будет выстрел")]
    public float FIRERATE;
    [Tooltip("ћаксимальное рассто€ние которое может пролететь пул€")]
    public float BULLET_RANGE;
    [Tooltip(" оличество патронов которое будет добавл€тьс€ если подобрать данное оружие")]
    public float AMMO;
    public Dictionary<string, float> GetData()
    {
        Dictionary<string, float> data = new Dictionary<string, float> { };
        data["DAMAGE"] = DAMAGE;
        data["FIRERATE"] = FIRERATE;
        data["BULLET_RANGE"] = BULLET_RANGE;
        data["AMMO"] = AMMO;
        return data;
    }

}
