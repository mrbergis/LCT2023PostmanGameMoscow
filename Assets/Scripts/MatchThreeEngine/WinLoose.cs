using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLoose : MonoBehaviour
{
    private LvlTimer Timer;
    private ScoreCounter ScoreCounter;
    public GameObject DeathScreen;
    [SerializeField]
    public GameObject WinScreen;
    private AudioSource loosesound;
    public string sceneName;

    public void Loose()
    {
        if (!DeathScreen.activeSelf)
        {
            DeathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Win()
    {
        if (!WinScreen.activeSelf)
        {
            WinScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    // Start is called before the first frame update

    void Awake()
    {
        ScoreCounter = GameObject.FindGameObjectWithTag("GemsCounter").GetComponent<ScoreCounter>();
        Timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<LvlTimer>();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName); // Загрузка указанной сцены
    }

    // Update is called once per frame
    void Update()
    {
 
        if (ScoreCounter.Meter >= 15 && SceneManager.GetActiveScene().name == "MatchThree")
        {
            Win();
        }

        else if (ScoreCounter.Meter >= 20 && SceneManager.GetActiveScene().name == "Normal")
        {
            Win();
        }

        else if (ScoreCounter.Meter >= 30 && SceneManager.GetActiveScene().name == "Hard")
        {
            Win();
        }

        else if (Timer.timeStart <= 0)
        {
            Loose();
        }

        else
        {
            return;
        }
    }
}
