using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public string PATH;
    public PlayerDataSO player;

    public void Awake()
    {
        PATH = Application.persistentDataPath + PATH;
    }

    public void SaveGame()
    {
        if (!Directory.Exists(PATH)) Directory.CreateDirectory(PATH);
        if (!Directory.Exists(PATH + player.saveName)) Directory.CreateDirectory(PATH + player.saveName);
        FileStream file = File.Create(PATH + player.saveName + ".save");
        var json = JsonUtility.ToJson(player);
        BinaryFormatter bF = new BinaryFormatter();
        bF.Serialize(file, json);
        file.Close();
    }

    public void LoadGame()
    {
        BinaryFormatter bF = new BinaryFormatter();
        if (File.Exists(PATH + player.saveName + ".save"))
        {
            FileStream file = File.Open(PATH + player.saveName + ".save", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bF.Deserialize(file), player);
            file.Close();
        }
    }

    public void GetSavedGames()
    {
        //foreach save file in directory
        //if (File.Exists(PATH + player.saveName)) AddSaveFileButton();
    }
}
