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

    public void SkipGame()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("BaseScene");
    }

    public void QuitGame()
    {

    }

    public void NewLevel()
    {
        LevelDataManagement data = LevelDataManagement.Instance;
        LevelDataManagement.Instance.UpdateLevelData(level: data.Level + 1, current: data.Current);
        SceneManager.LoadScene("BaseScene");
    }

    public void ContinueFromLastSave()
    {
        LevelDataManagement data = LevelDataManagement.Instance;
        LevelDataManagement.Instance.UpdateLevelData(level: data.Level + 1, current: data.Current);
        SceneManager.LoadScene("BaseScene");
    }

    public void Buy()
    {

    }

}
