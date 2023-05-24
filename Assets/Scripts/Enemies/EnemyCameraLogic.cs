using System;
using System.Collections;
using System.Collections.Generic;
using Attributes;
using Movement;
using UnityEngine;

public class EnemyCameraLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject player = other.gameObject;
            player.GetComponent<Mover>().Cancel();
            player.GetComponent<Health>().Die();
        }
    }
}
