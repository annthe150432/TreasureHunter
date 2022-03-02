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
        SceneManager.LoadScene("ShopScene");
    }

    public void RestartCurrent()
    {
        SceneManager.LoadScene("BaseScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewLevel()
    {
        LevelDataManagement.Instance.UpdateLevelData(level: LevelDataManagement.Instance.Level + 1, current: LevelDataManagement.Instance.Current);
        SceneManager.LoadScene("BaseScene");
    }

    public void RestartAll()
    {
        DataManagement<SaveData>.DeleteSaveFile("savegame");
        LevelDataManagement.Instance.UpdateLevelData(level: 0, current: 0);
        SceneManager.LoadScene("HomeScene");
    }

    public void ContinueFromLastSave()
    {
        LevelDataManagement data = LevelDataManagement.Instance;
        LevelDataManagement.Instance.UpdateLevelData(level: data.Level, current: data.Current);
        SceneManager.LoadScene("BaseScene");
    }

    public void SpendMoney(int spend)
    {
        if (spend > LevelDataManagement.Instance.Current)
        {
            return;
        }
        LevelDataManagement.Instance.UpdateLevelData(current: LevelDataManagement.Instance.Current - spend);
    }

}
