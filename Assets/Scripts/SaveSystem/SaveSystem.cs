using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    public static class SaveSystem
    {
        private static string levelKey = "LevelKey";
        private static string saveDataKey = "saveDataKey";
        
        private static string positionXKey = "positionXKey";
        private static string positionYKey = "positionYKey";
        private static string positionZKey = "positionZKey";

         
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
             // PlayerPrefs.DeleteKey(levelKey);
             // PlayerPrefs.DeleteKey(saveDataKey);
             //
             // PlayerPrefs.DeleteKey(positionXKey);
             // PlayerPrefs.DeleteKey(positionYKey);
             // PlayerPrefs.DeleteKey(positionZKey);
             PlayerPrefs.DeleteAll();
         }
         
         public static void SavePosition(PlayerDataSO playerPosition)
         {
             var position = playerPosition.ConvertTransformToArray();
             
             PlayerPrefs.SetFloat(positionXKey, position[0]);
             PlayerPrefs.SetFloat(positionYKey, position[1]);
             PlayerPrefs.SetFloat(positionZKey, position[2]);
         }

         public static Vector3 LoadPosition()
         {
             Debug.Log(PlayerPrefs.GetFloat(positionXKey));

             return new Vector3(
                 PlayerPrefs.GetFloat(positionXKey),
                 PlayerPrefs.GetFloat(positionYKey),
                 PlayerPrefs.GetFloat(positionZKey)
             );
         }
    }
}