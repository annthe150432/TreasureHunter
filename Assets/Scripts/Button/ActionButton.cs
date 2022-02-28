using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{

    public void PauseGame()
    {
        Time.timeScale = 0;
        GameObject canvas = GameObject.FindGameObjectsWithTag("CanvasPause")[0];
        canvas.GetComponent<Canvas>().sortingOrder = 5;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        GameObject canvas = GameObject.FindGameObjectsWithTag("CanvasPause")[0];
        canvas.GetComponent<Canvas>().sortingOrder = 0;
    }

    void SkipGame()
    {

    }
}
