using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public class DataManagement<T>
{
    public static T ReadDataFromFile(string filename, bool isSavedGame)
    {
        filename = filename + ".json";
        string path = Path.Combine(Application.dataPath, @"data/", filename);
        if (isSavedGame) path = Path.Combine(Application.persistentDataPath, @"data/", filename);
        Debug.Log(path);
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Not found " + path);
        }
        string fileContent = File.ReadAllText(path);
        T data = JsonConvert.DeserializeObject<T>(fileContent);
        return data;
    }

    public static void DumpDataToFile(string filename, T data)
    {
        filename = filename + ".json";
        string path = Path.Combine(Application.persistentDataPath, @"data/", filename);
        string fileContent = JsonConvert.SerializeObject(data);
        FileStream fs = new FileStream(path, FileMode.Create);
        File.WriteAllText(path, fileContent);
    }

    public static void DeleteSaveFile(string filename)
    {
        filename = filename + ".json";
        String path = Path.Combine(Application.persistentDataPath, @"data/", filename);
        if (!File.Exists(path))
        {
            return;
        }
        File.Delete(path);
    }
}

