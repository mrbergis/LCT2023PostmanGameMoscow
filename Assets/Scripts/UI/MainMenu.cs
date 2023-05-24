using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(nextSceneName);
    }
    
    public void ExitGame()
    {
        Debug.Log("Exiting the game");
        Application.Quit();
    }
}
