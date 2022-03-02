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
                        SaveData saveData = DataManagement<SaveData>.ReadDataFromFile("savegame", true);
                        if (saveData != null) instance.CanContinue = true;
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
    public int Current { get; set; } = 1500;
    public int DynamiteCount { get; set; } = 0;
    public bool CanContinue { get; set; } = false;
    public bool NextLevel { get; set; } = true;
    private const int totalDynamite = 5;

    public SaveData saveData;
    public void UpdateLevelData(int level = -1, int current = -1)
    {
        if (level != -1)
        {
            List<LevelDetail> levelDetails = DataManagement<List<LevelDetail>>.ReadDataFromFile("leveldetails", false);
            Level = level;
            LevelDetail detail = levelDetails.Find(lv => lv.Level == Level);
            if (detail != null)
            {
                Target = detail.Target;
            }
            else
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

}
