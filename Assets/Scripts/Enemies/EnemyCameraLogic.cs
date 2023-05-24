using System;
using System.Collections;
using System.Collections.Generic;
using Attributes;
using Movement;
using UnityEngine;

public class EnemyCameraLogic : MonoBehaviour
{
    [SerializeField] private bool kill;

    [SerializeField] private Transform respawnPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject player = other.gameObject;
            if (kill)
            {
                player.GetComponent<Mover>().Finish();
                player.GetComponent<Health>().Die();
            }else if (respawnPosition)
            {
                player.transform.position = respawnPosition.position;
                player.GetComponent<Mover>().Cancel();
            }
            
            
        }
    }
}
