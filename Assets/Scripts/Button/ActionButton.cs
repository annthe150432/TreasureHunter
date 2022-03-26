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
        GameObject canvas = GameObject.FindGameObjectWithTag("CanvasPause");
        canvas.GetComponent<Canvas>().enabled = true;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        GameObject canvas = GameObject.FindGameObjectWithTag("CanvasPause");
        canvas.GetComponent<Canvas>().enabled = false;
    }

    public void SkipGame()
    {
        GameObject targetMoneyGameObject = GameObject.FindGameObjectWithTag("TargetMoney");
        GameObject currentMoneyGameObject = GameObject.FindGameObjectWithTag("CurrentMoney");
        int target = int.Parse(targetMoneyGameObject.GetComponent<Text>().text);
        int current = int.Parse(currentMoneyGameObject.GetComponent<Text>().text);
        if (current < target || !LevelDataManagement.Instance.NextLevel)
        {
            SceneManager.LoadScene("ResultScene");
           
        }       
        else
        {
            SceneManager.LoadScene("ShopScene");
        }
    }

    public void RestartCurrent()
    {

        GameObject currentMoneyGameObject = GameObject.FindGameObjectWithTag("CurrentMoney");
        CurrentPointHandler currentPointHandler = currentMoneyGameObject.GetComponent<CurrentPointHandler>();
        currentPointHandler.RestartLevel = true;
        SceneManager.LoadScene("BaseScene");
        Time.timeScale = 1;
    }

    public void ExitCurrent()
    {
        GameObject currentMoneyGameObject = GameObject.FindGameObjectWithTag("CurrentMoney");
        CurrentPointHandler currentPointHandler = currentMoneyGameObject.GetComponent<CurrentPointHandler>();
        currentPointHandler.RestartLevel = true;
        SceneManager.LoadScene("HomeScene");
        Time.timeScale = 1;
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
        LevelDataManagement.Instance.CanContinue = false;
        LevelDataManagement.Instance.AddedTime = 0;
        LevelDataManagement.Instance.AddDiamondValue = false;
        LevelDataManagement.Instance.AddPullForce = false;
        LevelDataManagement.Instance.DoubleStoneValue = false;
        LevelDataManagement.Instance.DynamiteCount = 0;
        SceneManager.LoadScene("HomeScene");
    }

    public void ContinueFromLastSave()
    {
        LevelDataManagement data = LevelDataManagement.Instance;
        LevelDataManagement.Instance.UpdateLevelData(level: data.saveData.Level, current: data.saveData.Current);
        SceneManager.LoadScene("BaseScene");
    }

    public void TestModifyClock()
    {

    }

}
