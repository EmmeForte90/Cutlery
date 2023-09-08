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
        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/savegame.dat";

        using (FileStream stream = new FileStream(savePath, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
    }

    public PlayerStats LoadGameData()
    {
        string savePath = Application.persistentDataPath + "/savegame.dat";
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(savePath, FileMode.Open))
            {
                return formatter.Deserialize(stream) as PlayerStats;
            }
        }
        else
        {
            Debug.LogWarning("Save file not found.");
            return null;
        }
    }
}