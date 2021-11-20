using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    [Tooltip("Дамаг")]
    public float DAMAGE;
    [Tooltip("Темп стрельбы по типу если написано 0.5 то каждую половину секунды будет выстрел")]
    public float FIRERATE;
    [Tooltip("Максимальное расстояние которое может пролететь пуля")]
    public float BULLET_RANGE;
    [Tooltip("Количество патронов которое будет добавляться если подобрать данное оружие")]
    public float AMMO_ADD;
    [Tooltip("Угол разброса пули")]
    public float ANGLES_SPREAD;
    [Tooltip("Тип пули: 1-обычная, 2-рпг")]
    public float BULLET_TYPE;
    [Tooltip("Максимальное расстояние на которое распостраняеться дамаг от взрыва")]
    public float MAX_EXPLODE_DIST;
    [Tooltip("Сколько пуль выстрелить за один встрел, к примеру дробовик")]
    public float BULLETS_PER_SHOT;
    [Tooltip("Модель для подбора патронов")]
    public GameObject AMMO_MODEL;
    public Dictionary<string, float> GetData()
    {
        Dictionary<string, float> data = new Dictionary<string, float> { };
        data["DAMAGE"] = DAMAGE;
        data["FIRERATE"] = FIRERATE;
        data["BULLET_RANGE"] = BULLET_RANGE;
        data["AMMO_ADD"] = AMMO_ADD;
        data["ANGLES_SPREAD"] = ANGLES_SPREAD;
        data["BULLET_TYPE"] = BULLET_TYPE;
        data["MAX_EXPLODE_DIST"] = MAX_EXPLODE_DIST;
        data["BULLETS_PER_SHOT"] = BULLETS_PER_SHOT;
        return data;
    }

}
