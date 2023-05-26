using UnityEngine;
using UnityEngine.UI;

public class QuizWindowController : MonoBehaviour
{
    public Button openWinWindowButton;
    public GameObject winWindow;
    public Button openLooseWindowButton;
    public GameObject quizWindow;
    public WinWindowController winWindowController;
    public LooseWindowController looseWindowController;


    private void Start()
    {
        openWinWindowButton.onClick.AddListener(OpenWinWindow);
        openLooseWindowButton.onClick.AddListener(OpenLooseWindow);
    }

    private void OpenWinWindow()
    {
        winWindowController.OpenWindow();
    }

    private void OpenLooseWindow()
    {
        looseWindowController.OpenWindow();
    }

    public void CloseWindow()
    {
        winWindow.SetActive(false);
        quizWindow.SetActive(false);
    }


}
