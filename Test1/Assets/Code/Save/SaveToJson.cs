using System;
using System.IO;
using UnityEngine;

public class SaveToJson
{
    public static SaveToJson Instance;
    private StartSettingsController _startSettingsController;

    private string _savePath;
    private string _fileName;
    public SaveToJson(StartSettingsController startSettingsController)
    {
        Instance = this;
        _startSettingsController = startSettingsController;
    }

    public void Awake()
    {
        _fileName = "SaveData";

#if UNITY_ANDROID && !UNITY_EDITOR
    _savePath = Path.Combine(Application.persistentDataPath, _fileName);
#else
    _savePath = Path.Combine(Application.dataPath, _fileName);
#endif
    }

    public void SaveToFile()
    {
        string json = JsonUtility.ToJson(SaveData.Instance, true);
        File.WriteAllText(_savePath, json);
    }

    public void LoadFile()
    {
        if (!File.Exists(_savePath))
        {
            _startSettingsController.StartSettings();
            SaveToFile();
            return;
        }

        string json = File.ReadAllText(_savePath);
        SaveData.Instance = JsonUtility.FromJson<SaveData>(json);
    }
}
