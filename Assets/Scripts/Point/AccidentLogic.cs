using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentLogic : MonoBehaviour
{
    
    [SerializeField] private GameObject canvasAccident;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Random.Range(0, 100) < 40)
            {
                canvasAccident.SetActive(true);
            }
            other.GetComponent<PathMovement>().StopMoving();
            other.gameObject.transform.position = Vector3.zero;
        }
    }
}
