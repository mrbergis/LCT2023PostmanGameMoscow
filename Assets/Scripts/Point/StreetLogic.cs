using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StreetLogic : MonoBehaviour
{
    [SerializeField] private StreetData streetData; 
    
    private void Start()
    {
        gameObject.SetActive(streetData.streetActive);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(streetData.streetName);
        }
    }
}
