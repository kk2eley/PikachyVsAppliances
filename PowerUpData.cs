using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpData : MonoBehaviour
{
    [Tooltip("Сколько скорости добавить к оригинальному значению")]
    public float SPEED_ADD;
    [Tooltip("Длительность эффекта")]
    public float EFFECT_LENGTH;
    [Tooltip("Даёться ли неуязвимость (0:false,1:true")]
    public float INF_HEALTH;
    [Tooltip("Даётьса ли бонус на бесконечные патроны (0:false,1:true")]
    public float INF_AMMO;
    [Tooltip("Множитель дамага от игрока")]
    public float DAMAGE_MULTIPLER;
    [Tooltip("Множитель скорострельности игрока")]
    public float FIRERATE_MULTIPLER;
    public Dictionary<string,float> GetData()
    {
        Dictionary<string, float> data = new Dictionary<string, float> { };
        data["SPEED_ADD"] = SPEED_ADD;
        data["EFFECT_LENGTH"] = EFFECT_LENGTH;
        data["INF_HEALTH"] = INF_HEALTH;
        data["INF_AMMO"] = INF_AMMO;
        data["DAMAGE_MULTIPLER"] = DAMAGE_MULTIPLER;
        data["FIRERATE_MULTIPLER"] = FIRERATE_MULTIPLER;
        return data;
    }
}
