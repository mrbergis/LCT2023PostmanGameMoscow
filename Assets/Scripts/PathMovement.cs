using UnityEngine;

public class PathMovement : MonoBehaviour
{
    public Transform[] waypoints1; 
    public Transform[] waypoints2; 
    public Transform[] waypoints3; 
    public float normalSpeed = 5f; 
    public float boostedSpeed = 10f; 

    private Transform[] currentWaypoints; 
    private int currentWaypointIndex = 0;
    private bool isMoving = false; 
    private float currentSpeed; 

    private void Start()
    {
        currentSpeed = normalSpeed; 
    }
    
    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoints[currentWaypointIndex].position, currentSpeed * Time.deltaTime);
            
            if (transform.position == currentWaypoints[currentWaypointIndex].position)
            {
                if (currentWaypointIndex < currentWaypoints.Length - 1)
                {
                    currentWaypointIndex++; 
                }
                else
                {
                    isMoving = false; 
                }
            }
        }
    }

    public void StartMovement(Transform[] selectedWaypoints)
    {
        currentWaypoints = selectedWaypoints; 
        currentWaypointIndex = 0;
        isMoving = true; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoostTrigger"))
        {
            currentSpeed = boostedSpeed;
        }
        else if (other.CompareTag("SpeedResetTrigger"))
        {
            currentSpeed = normalSpeed;
        }
    }
}
