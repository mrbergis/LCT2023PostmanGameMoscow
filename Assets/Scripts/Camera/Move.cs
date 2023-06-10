using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    float speed = 3.0f;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        transform.Translate(new Vector2(speed * Time.deltaTime,0f));
    }
}
