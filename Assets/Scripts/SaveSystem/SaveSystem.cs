using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    public static class SaveSystem
    {
        private static string levelKey = "LevelKey";
         private static string saveDataKey = "saveDataKey";

         
         public static void SaveGameData(int levelIndexToSave)
         {

             SaveLevel(levelIndexToSave);
             PlayerPrefs.SetInt(saveDataKey, 1);
         }
         
         private static void SaveLevel(int levelIndex)
         {
             PlayerPrefs.SetInt(levelKey, levelIndex);
         }

         public static int LoadLevelIndex()
         {
             if (IsSaveDataPresent())
                 return PlayerPrefs.GetInt(levelKey);
             return -1;
         }

         private static bool IsSaveDataPresent()
         {
             return PlayerPrefs.GetInt(saveDataKey) == 1;
         }

         public static void ResetSaveData()
         {
             PlayerPrefs.DeleteKey(levelKey);
             PlayerPrefs.DeleteKey(saveDataKey);
         }
    }
}