using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreCounter : MonoBehaviour
{ 

    public static int Meter; //  оличество очков на данный момент (статическа€ переменна€)
    private TextMeshProUGUI crystallcounter; // “екст, который видит игрок

    void Start() // „то происходит при запуске игры
    {
        crystallcounter = GetComponent<TextMeshProUGUI>(); //  ристалкаунтер становитс€ ссылкой на компонент текста
        Meter = 0; // —четчик очков изначально равен 0
    }

    void Update() // „то происходит каждую секунду игры
    {
        if (SceneManager.GetActiveScene().name == "MatchThree")
        {
            crystallcounter.text = Meter + "/15"; // “екст в кристалкаунтере это текущее количество очков
        }
        else if (SceneManager.GetActiveScene().name == "Normal")
        {
            crystallcounter.text = Meter + "/20"; // “екст в кристалкаунтере это текущее количество очков
        }
        else if (SceneManager.GetActiveScene().name == "Hard")
        {
            crystallcounter.text = Meter + "/30"; // “екст в кристалкаунтере это текущее количество очков
        }
        else
        {
            return;
        }
    }
}
