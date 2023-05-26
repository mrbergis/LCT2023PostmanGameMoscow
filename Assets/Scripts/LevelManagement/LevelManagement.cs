using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelManagement : MonoBehaviour
    {
        [SerializeField] private StreetData dataScene;
        
        [SerializeField] float fadeOutTime = 1f;
        [SerializeField] float fadeInTime = 2f;
        [SerializeField] float fadeWaitTime = 0.5f;
        
        [SerializeField]
        private int level2DSceneBuildIndex, menuSceneBuildIndex, winSceneBuildIndex;
        //winSceneBuildIndex - последняя сцена которую мы собираемся показать
        public void RestartCurrentLevel()
        {
            LoadSceneWithIndex(SceneManager.GetActiveScene().buildIndex);
        }

        public void Load2DLevelWin()
        {
            dataScene.streetActive = false;
            LoadSceneWithIndex(level2DSceneBuildIndex);
        }
        
        public void Load2DLevel()
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
        
        public void LoadSaveScene()
        {
            LoadSceneWithIndex(SaveSystem.SaveSystem.LoadLevelIndex());
        }

        public void LoadSceneWithIndex(int index)
        {
            StartCoroutine(Transition(index));
        }
        
        private IEnumerator Transition(int index)
        {
            Fader fader = FindObjectOfType<Fader>();
        
            yield return fader.FadeOut(fadeOutTime);
        
            yield return SceneManager.LoadSceneAsync(index);
        
            yield return new WaitForSeconds(fadeWaitTime);
            fader.FadeIn(fadeInTime);
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
