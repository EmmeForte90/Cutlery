using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGameData(PlayerStats data)
    {
        string savePath = Application.persistentDataPath + "/savegame.json";
        string jsonData = JsonUtility.ToJson(data);

        try
        {
            File.WriteAllText(savePath, jsonData);
            Debug.Log("Game data saved.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error saving game data: " + e.Message);
        }
    }

    public PlayerStats LoadGameData()
    {
        string savePath = Application.persistentDataPath + "/savegame.json";
        
        if (File.Exists(savePath))
        {
            try
            {
                string jsonData = File.ReadAllText(savePath);
                PlayerStats data = JsonUtility.FromJson<PlayerStats>(jsonData);
                return data;
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error loading game data: " + e.Message);
                return null;
            }
        }
        else
        {
            Debug.LogWarning("Save file not found.");
            return null;
        }
    }
}