using UnityEngine;
using System.IO;

public class FileChecker : MonoBehaviour
{
    public GameObject Continue;
    public string NameScene;
   void Start()
    {
        string folderPath = "C:/Users/Utente/AppData/LocalLow/DefaultCompany/CutleryWarrior";
        string fileName = "SaveFile.es3";
        string filePath = Path.Combine(folderPath, fileName);
        PlayerStats.instance.NameScene = NameScene;

        if (File.Exists(filePath))
        {
            Debug.Log("Il file specificato esiste nella cartella specificata.");
            Continue.SetActive(true);
        }
        else
        {
            Debug.Log("Il file specificato non esiste nella cartella specificata.");
            Continue.SetActive(false);
        }
    }
}