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
    public float AMMO_ADD;
    [Tooltip("���� �������� ����")]
    public float ANGLES_SPREAD;
    [Tooltip("��� ����: 1-�������, 2-���")]
    public float BULLET_TYPE;
    [Tooltip("������������ ���������� �� ������� ���������������� ����� �� ������")]
    public float MAX_EXPLODE_DIST;
    [Tooltip("������� ���� ���������� �� ���� ������, � ������� ��������")]
    public float BULLETS_PER_SHOT;
    [Tooltip("������ ��� ������� ��������")]
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
