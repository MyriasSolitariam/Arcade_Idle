using System.IO;
using UnityEngine;

public abstract class SaveLoadSystem : MonoBehaviour
{
    [SerializeField] protected MonoBehaviour _serializableData;

    [SerializeField] protected string _dataPath;

    private ISerializableData _data;

    public virtual void Awake()
    {
        if (_serializableData is ISerializableData)
        {
            _data = _serializableData as ISerializableData;
        }
        else
        {
            throw new System.NotImplementedException("Data is not Serializable! Must derive from ISerializableData");
        }
    }

    protected void Start()
    {
        if (File.Exists(_dataPath))
        {
            Load();
        }
    }

    public virtual void Save()
    {
        _data.SaveValues();

        string gameData = JsonUtility.ToJson(_data);

        Upload(_dataPath, gameData);
    }

    public virtual void Load()
    {
        Download(_dataPath, _data);

        _data.SetValues();
    }

    protected void Upload(string path, string jsonString)
    {
        using (StreamWriter sw = new StreamWriter(path, false))
        {
            sw.WriteLine(jsonString);
        }
    }

    protected void Download(string path, ISerializableData monoBehaviour)
    {
        string jsonString;

        using (StreamReader sr = new StreamReader(path))
        {
            jsonString = sr.ReadToEnd();
        }

        JsonUtility.FromJsonOverwrite(jsonString, monoBehaviour);
    }

    protected void DeleteSaveFile()
    {
        if (File.Exists(_dataPath))
        {
            File.Delete(_dataPath);
        }
    }
}
