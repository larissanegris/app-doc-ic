using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool loadFromSave;

    private GameData gameData;

    public static DataPersistenceManager instance { get; private set; }

    private FileDataHandler dataHandler;

    public List<IDataPeristence> dataPersistenceObjects;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one Data persistence Manager");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        if (!loadFromSave)
        {
            NewGame();
            return;
        }
            
        this.gameData = dataHandler.Load();
        //load saved data
        if(this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data do defaults");
            NewGame();
        }

        foreach(IDataPeristence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
        Debug.Log("Loaded number: " + gameData.numberCreatedObjects);
    }

    public void SaveGame()
    {
        foreach (IDataPeristence dataPeristenceObj in dataPersistenceObjects)
        {
            dataPeristenceObj.SaveData(ref gameData);
        }
        Debug.Log("Saved number: " + gameData.numberCreatedObjects);

        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }


    private List<IDataPeristence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPeristence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPeristence>();

        return new List<IDataPeristence>(dataPersistenceObjects);
    }
}
