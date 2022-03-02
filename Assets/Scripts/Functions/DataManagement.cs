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
        string content = "";
        string datafolder = @"data/";
        if (isSavedGame)
        {
            filename = filename + ".json";
            String path = Path.Combine(Application.persistentDataPath, datafolder, filename);
            Debug.Log(path);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Not found " + path);
            }
            content = File.ReadAllText(path);
        }
        else
        {
            TextAsset file = Resources.Load(datafolder + filename) as TextAsset;
            content = file.text;
        }
        
        T data = JsonConvert.DeserializeObject<T>(content);
        return data;
    }

    public static void DumpDataToFile(string filename, T data)
    {
        filename = filename + ".json";
        string path = Path.Combine(Application.persistentDataPath, @"data/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        path = Path.Combine(path, filename);
        string fileContent = JsonConvert.SerializeObject(data);
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