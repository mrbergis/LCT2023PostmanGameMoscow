using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SaveSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelManagement.LevelManagement sceneManagement;
    
    public void SaveGameData()
    {
        IEnumerable<ISaveData> saveDataScripts = FindObjectsOfType<MonoBehaviour>().OfType<ISaveData>();
        foreach (ISaveData item in saveDataScripts)
        {
            item.SaveData();
        }
            
        SaveSystem.SaveSystem.SaveGameData(sceneManagement.GetNextLevelIndex());
    }
}
