using UnityEngine;
using UnityEngine.UI;

public class WinWindowController : MonoBehaviour
{
    public Button closeButton;
    public GameObject winWindow;
    public QuizWindowController quizWindowController;
    public GameObject pathMovementObject;
    public Button disableWaypointButton;
    public PathMovement pathMovement;


    private void Start()
    {
        closeButton.onClick.AddListener(CloseWindow);
        disableWaypointButton.onClick.AddListener(DisableCurrentWaypoint);
    }

    public void CloseWindow()
    {
        winWindow.SetActive(false);
        quizWindowController.CloseWindow();
    }


    public void OpenWindow()
    {
        winWindow.SetActive(true);
    }

    private void DisableCurrentWaypoint()
    {
        if (pathMovement != null)
        {
            pathMovement.DisableCurrentWaypoint();
        }
    }


}
