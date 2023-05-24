using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f; 

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        MoveRight();
    }

    private void MoveRight()
    {
        Vector2 movement = new Vector2(speed * Time.deltaTime, 0f);
        transform.Translate(movement);
    }
}
