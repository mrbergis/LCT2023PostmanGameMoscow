using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPatrolPath : MonoBehaviour
{
    [SerializeField]
    private PatrolPath patrolPath;

    [Range(0.1f, 1)]
    [SerializeField]
    private float arriveDistance = 1;
    
    [SerializeField]
    private float waitTime = 0.5f;
    [SerializeField]
    private bool isWaiting = false;
    [SerializeField]
    private Vector3 currentPatrolTarget = Vector3.zero;

    [SerializeField]
    private float speed = 5f;
    private bool isInitialized = false;
    [SerializeField]
    private Transform agent;
    private int currentIndex = -1;

    private void Update()
    {
        if (!isWaiting)
        {
            if (patrolPath.Length < 2)
                return;
            if (!isInitialized)
            {
                var currentPathPoint = patrolPath.GetClosestPathPoint(agent.position);
                this.currentIndex = currentPathPoint.Index;
                this.currentPatrolTarget = currentPathPoint.Position;
                isInitialized = true;
            }
            
            Vector3 direction = currentPatrolTarget - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);

            if (Vector3.Distance(transform.rotation.eulerAngles, rotation.eulerAngles) < arriveDistance)
            {
                isWaiting = true;
                StartCoroutine(WaitCoroutine());
                return;
            }
            
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
    }
    
    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        var nextPathPoint = patrolPath.GetNextPathPoint(currentIndex);
        currentPatrolTarget = nextPathPoint.Position;
        currentIndex = nextPathPoint.Index;

        isWaiting = false;
    }
}
