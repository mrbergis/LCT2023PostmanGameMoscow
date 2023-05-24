using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelManagement : MonoBehaviour
    {
        [SerializeField]
        private int level2DSceneBuildIndex, menuSceneBuildIndex, winSceneBuildIndex;
        //winSceneBuildIndex - последняя сцена которую мы собираемся показать
        public void RestartCurrentLevel()
        {
            LoadSceneWithIndex(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadStartLevel()
        {
            LoadSceneWithIndex(level2DSceneBuildIndex);
        }

        public void LoadNextLevel()
        {
            LoadSceneWithIndex(GetNextLevelIndex());
        }

        public void LoadMenu()
        {
            LoadSceneWithIndex(menuSceneBuildIndex);
        }

        public void LoadWinScene()
        {
            LoadSceneWithIndex(winSceneBuildIndex);
        }

        public void LoadSceneWithIndex(int index)
        {
            SceneManager.LoadScene(index);
        }

        public int GetNextLevelIndex()
        { 
            int index = SceneManager.GetActiveScene().buildIndex + 1;
            if (index < SceneManager.sceneCountInBuildSettings)
            {
                return index;
            }
            else
            {
                return winSceneBuildIndex;
            }

        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
             Application.Quit();
#endif
        }
    }
}
