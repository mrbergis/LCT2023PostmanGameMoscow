using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LvlTimer : MonoBehaviour
{
    private ScoreCounter ScoreCounter;
    public float timeStart;
    private TextMeshProUGUI timerText;
    // Start is called before the first frame update 

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        Time.timeScale = 1f;
        timerText.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timeStart).ToString();
    }
}
