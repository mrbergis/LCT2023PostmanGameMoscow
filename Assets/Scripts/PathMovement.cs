using UnityEngine;

public class PathMovement : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerData;
    
    public Transform[] waypoints1;
    public Transform[] waypoints2;
    public Transform[] waypoints3;
    public float normalSpeed = 5f;
    public float boostedSpeed = 10f;
    public GameObject window;
    private GameObject currentWaypointObject;
    private Waypoint currentWaypoint;

    private Transform[] currentWaypoints;
    private int currentWaypointIndex = 0;
    private bool isMoving = false;
    private float currentSpeed;

    
    private void Awake()
    {
        playerData.playerPosition = transform;
    }

    private void Start()
    {
        currentSpeed = normalSpeed;
        LoadData();
        
        transform.position = playerData.playerPosition.position;

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
                    //window.SetActive(true); 
                }
            }
        }
    }

    public void StopMoving()
    {
        isMoving = false;
    }
    public void SetPosition()
    {
        
    }
    public void StartMovement(Transform[] selectedWaypoints)
    {
        currentWaypoints = selectedWaypoints;
        //currentWaypointIndex = 0;
        currentWaypointIndex = GetIndexNearestPoint(selectedWaypoints);
        isMoving = true;
        
        currentWaypoint = currentWaypoints[currentWaypointIndex].GetComponent<Waypoint>();
        currentWaypointObject = currentWaypoints[currentWaypointIndex].gameObject;
    }
    
    private int GetIndexNearestPoint(Transform[] selectedWaypoints)
    {
        int currentIndex = 0;
        var minDistance =  Vector3.Distance(transform.position, selectedWaypoints[0].position);
        for (int i = 0; i < selectedWaypoints.Length; i++)
        {
            var Distance = Vector3.Distance(transform.position, selectedWaypoints[i].position);
            if (minDistance > Distance)
            {
                currentIndex = i;
            }
        }
        return currentIndex;
    }
    
    private void OnDestroy()
    {
        SaveData();
    }

    public void LoadData()
    {
        var newPosition = SaveSystem.SaveSystem.LoadPosition();
        if (newPosition != Vector3.zero)
            playerData.playerPosition.position = newPosition;
    }

    public void SaveData()
    {
        playerData.playerPosition = transform;
        SaveSystem.SaveSystem.SavePosition(playerData);
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

    public void DisableCurrentWaypoint()
    {
        if (currentWaypointObject != null)
        {
            currentWaypointObject.SetActive(false);
            currentWaypoints[currentWaypointIndex].gameObject.SetActive(false);

            GameObject markObject = currentWaypoints[currentWaypointIndex].GetComponent<Waypoint>().mark;
            if (markObject != null)
            {
                markObject.SetActive(true);
            }
        }
    }


}
