using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveGUI : MonoBehaviour
{
    public GameObject Data;
    void Update()
    {
        var data = Data.GetComponent<WavesDirector>().Wave;
        this.GetComponent<Text>().text = "Wave: " + data;
    }
}
