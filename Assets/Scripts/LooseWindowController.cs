using UnityEngine;

public class LooseWindowController : MonoBehaviour
{
    public GameObject looseWindow;

    public void OpenWindow()
    {
        looseWindow.SetActive(true);
    }

    public void CloseWindow()
    {
        looseWindow.SetActive(false);
    }
}
