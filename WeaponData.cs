using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    [Tooltip("�����")]
    public float DAMAGE;
    [Tooltip("���� �������� �� ���� ���� �������� 0.5 �� ������ �������� ������� ����� �������")]
    public float FIRERATE;
    [Tooltip("������������ ���������� ������� ����� ��������� ����")]
    public float BULLET_RANGE;
    [Tooltip("���������� �������� ������� ����� ����������� ���� ��������� ������ ������")]
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
