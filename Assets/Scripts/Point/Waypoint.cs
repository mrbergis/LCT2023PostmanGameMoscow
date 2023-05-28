using System;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject mark;
    public PathMovement pathMovement;
    public Transform[] waypoints;

    [SerializeField] private GameObject canvas;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pathMovement.StartMovement(waypoints);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PathMovement>().StopMoving();
            canvas.SetActive(true);
            other.gameObject.transform.position = Vector3.zero;
        }
    }
}
