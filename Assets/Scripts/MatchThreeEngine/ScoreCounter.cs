using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreCounter : MonoBehaviour
{ 

    public static int Meter; // ���������� ����� �� ������ ������ (����������� ����������)
    private TextMeshProUGUI crystallcounter; // �����, ������� ����� �����

    void Start() // ��� ���������� ��� ������� ����
    {
        crystallcounter = GetComponent<TextMeshProUGUI>(); // �������������� ���������� ������� �� ��������� ������
        Meter = 0; // ������� ����� ���������� ����� 0
    }

    void Update() // ��� ���������� ������ ������� ����
    {
        if (SceneManager.GetActiveScene().name == "MatchThree")
        {
            crystallcounter.text = Meter + "/15"; // ����� � ��������������� ��� ������� ���������� �����
        }
        else if (SceneManager.GetActiveScene().name == "Normal")
        {
            crystallcounter.text = Meter + "/20"; // ����� � ��������������� ��� ������� ���������� �����
        }
        else if (SceneManager.GetActiveScene().name == "Hard")
        {
            crystallcounter.text = Meter + "/30"; // ����� � ��������������� ��� ������� ���������� �����
        }
        else
        {
            return;
        }
    }
}
