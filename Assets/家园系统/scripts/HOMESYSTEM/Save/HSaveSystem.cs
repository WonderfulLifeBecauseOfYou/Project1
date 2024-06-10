using Newtonsoft.Json;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class HSaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/º“‘∞œµÕ≥/SaveFile/";
    public const string FILE_NAME = "HomewSaveFile";
    private const string SAVE_EXTENTION = ".sav";

    public static string fileName { get; private set; }
    public static string filePath { get; private set; }

    public static void Initialize()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        { 
            Directory.CreateDirectory(SAVE_FOLDER);
            
        }
        fileName = FILE_NAME + SAVE_EXTENTION;
        filePath = SAVE_FOLDER + FILE_NAME + SAVE_EXTENTION;
    }

    public static void Save(HSaveData saveObject)
    {
        var settings = new JsonSerializerSettings();
        settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        string saveString = JsonConvert.SerializeObject(saveObject, settings);
        Debug.Log("Saved string: " + saveString);
        File.WriteAllText(filePath, saveString);
    }


    public static HSaveData Load()
    {
        if (File.Exists(filePath))
        {
            string saveString = File.ReadAllText(filePath);
            Debug.Log("Loaded string: " + filePath);
            HSaveData loaded = JsonConvert.DeserializeObject<HSaveData>(saveString);
            if(loaded == null)
            {
                return new HSaveData();
            }
            return loaded;
        }
        else
        {
            return new HSaveData();
        }
    }

}
