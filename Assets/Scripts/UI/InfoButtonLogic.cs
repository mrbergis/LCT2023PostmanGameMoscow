using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoButtonLogic : MonoBehaviour
{
    [SerializeField] private int tutorialSceneBuildIndex;
    [SerializeField] private int currentSceneBuildIndex;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(tutorialSceneBuildIndex);
            SaveSystem.SaveSystem.SaveGameData(currentSceneBuildIndex);
        }
    }
}
