using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGame : MonoBehaviour
{
    public void LoadGame()
    {
        Destroy(gameObject);
        Time.timeScale = 1;
    }
}
