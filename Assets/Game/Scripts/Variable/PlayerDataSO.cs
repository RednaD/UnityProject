using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    public string       saveName;
    public List<EnumSO> choices;
    public Scene        currentScene;
    //public CheckPoint   lastCheckPoint;

    public void AddChoice(EnumSO choice)
    {
        if (!choices.Contains(choice)) choices.Add(choice);
    }

    public void RemoveChoice(EnumSO choice)
    {
        if (choices.Contains(choice)) choices.Remove(choice);
    }
}
