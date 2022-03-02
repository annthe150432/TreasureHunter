using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClockHandler : MonoBehaviour
{
    public int CurrentLevel { get; set; } = 0;
    public CountdownTimer countdownTimer;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        countdownTimer = gameObject.AddComponent<CountdownTimer>();
        countdownTimer.Duration = 5;
        countdownTimer.Run();
        text = gameObject.GetComponent<Text>();
        CurrentLevel = LevelDataManagement.Instance.Level;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTimer.Running)
        {
            int minutes = (int)(countdownTimer.Duration / 60);
            int seconds = (int)(countdownTimer.Duration % 60);
            text.text = $"{minutes}:{seconds.ToString("D2")}";
        }
        else
        {
            GameObject targetMoneyGameObject = GameObject.FindGameObjectWithTag("TargetMoney");
            GameObject currentMoneyGameObject = GameObject.FindGameObjectWithTag("CurrentMoney");
            int target = int.Parse(targetMoneyGameObject.GetComponent<Text>().text);
            int current = int.Parse(currentMoneyGameObject.GetComponent<Text>().text);
            if (current < target)
            {
                SceneManager.LoadScene("ResultScene");
            }
            else
            {
                DataManagement<SaveData>.DumpDataToFile("data", new SaveData { Level = CurrentLevel, Current = current });
                LevelDataManagement.Instance.UpdateLevelData(level: CurrentLevel, current: current);
                if (LevelDataManagement.Instance.NextLevel)
                {
                    SceneManager.LoadScene("ShopScene");
                }
                else
                {
                    SceneManager.LoadScene("ResultScene");
                }
            }
        }
    }
}
