using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartPanel : MonoBehaviour
{
    public GameObject[] Hearts;
    public GameObject Target;
    public Texture type0;
    public Texture type1;

    void Start()
    {
        for(int i = 0; i < 10; ++i)
        {
            Hearts[i].GetComponent<RawImage>().texture = type0;

        }
    }
    void Active(int x)
    {
        Hearts[x].GetComponent<RawImage>().texture = type0;

    }
    void InActive(int x)
    {
        Hearts[x].GetComponent<RawImage>().texture = type1;
    }
    void Update()
    {
        float hp = Target.GetComponent<HealthSystem>().Health;
        for (int i = 0; i < 10; ++i)
        {
            if (hp < i * 10) InActive(i);
            else Active(i);
        }
    }
}
