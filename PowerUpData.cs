using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpData : MonoBehaviour
{
    [Tooltip("������� �������� �������� � ������������� ��������")]
    public float SPEED_ADD;
    [Tooltip("������������ �������")]
    public float EFFECT_LENGTH;
    [Tooltip("������ �� ������������ (0:false,1:true")]
    public float INF_HEALTH;
    [Tooltip("������ �� ����� �� ����������� ������� (0:false,1:true")]
    public float INF_AMMO;
    [Tooltip("��������� ������ �� ������")]
    public float DAMAGE_MULTIPLER;
    [Tooltip("��������� ���������������� ������")]
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
