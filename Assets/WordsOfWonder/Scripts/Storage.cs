using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Storage<T>
    where T : notnull
{
    private readonly string _path;
    private BinaryFormatter _formatter;

    public Storage(string fileName)
    {
        _path = Application.persistentDataPath + $"/{fileName}.save";
        _formatter = new BinaryFormatter();
    }

    public T Load(T defaultSaveData)
    {
        if (File.Exists(_path) == false)
        {
            Save(defaultSaveData);
            return defaultSaveData;
        }

        T savedData;
        using (FileStream file = File.Open(_path, FileMode.Open))
        {
            savedData = (T)_formatter.Deserialize(file);
        }
        return savedData;
    }

    public void Save(T saveData)
    {
        using (FileStream file = File.Create(_path))
        {
            _formatter.Serialize(file, saveData);
        }
    }
}