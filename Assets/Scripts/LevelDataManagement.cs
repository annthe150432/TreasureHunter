using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelDataManagement
{
    public static LevelDataManagement instance = null;
    private static readonly object instanceLock = new object();
    private LevelDataManagement() { }
    public static LevelDataManagement Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new LevelDataManagement();
                    try
                    {
                        SaveData saveData = DataManagement<SaveData>.ReadDataFromFile(saveGameFileName, true);
                        if (saveData != null) instance.CanContinue = true;
                        instance.saveData = saveData;
                    }
                    catch (FileNotFoundException) {
                        instance.CanContinue = false;
                    }
                }
                return instance;
            }
        }
    }
    public int Level { get; set; } = 0;
    public int Target { get; set; } = 0;
    public int Current { get; set; } = 50000;
    public int DynamiteCount { get; set; } = 0;
    public bool CanContinue { get; set; } = false;
    public bool NextLevel { get; set; } = true;
    private const int totalDynamite = 5;
    private const int BaseTarget = 650;
    private const string saveGameFileName = "savegame";

    public SaveData saveData;
    public void UpdateLevelData(int level = -1, int current = -1)
    {
        if (level != -1)
        {
            List<LevelDetail> levelDetails = DataManagement<List<LevelDetail>>.ReadDataFromFile("leveldetails", false);
            Level = level;
            Target = BaseTarget * (2 * (Level - 1) * (Level - 1) + 2 * (Level - 1) + 1);
            if (levelDetails.Find(lv => lv.Level == level) == null)
            {
                Level = 0;
                Target = 0;
            }
            NextLevel = levelDetails.Find(lv => lv.Level == Level + 1) != null;
        }
        if (current != -1)
        {
            Current = current;
        }
    }
    public void Continue()
    {
        if (CanContinue)
        {
            UpdateLevelData(level: saveData.Level, current: saveData.Current);
        }
    }

    public void UpdateDynamiteCount(bool added)
    {
        if (added)
        {
            if (DynamiteCount < totalDynamite)
            {
                DynamiteCount++;
            }
        }
        else
        {
            if (DynamiteCount > 0)
            {
                DynamiteCount--;
            }
        }
    }

    public void UpdateSaveData()
    {
        SaveData saveData = new SaveData();
        saveData.Current = Current;
        saveData.Level = Level;
        DataManagement<SaveData>.DumpDataToFile(saveGameFileName, saveData);
        this.saveData = saveData;
    }

}
