using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public PathMovement pathMovement; 
    public Transform[] waypoints; 

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pathMovement.StartMovement(waypoints);
        }
    }
}
