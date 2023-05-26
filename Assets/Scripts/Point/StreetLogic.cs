using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StreetLogic : MonoBehaviour
{
    [SerializeField] private StreetData streetData; 
    
    [SerializeField] float fadeOutTime = 1f;
    [SerializeField] float fadeInTime = 2f;
    [SerializeField] float fadeWaitTime = 0.5f;
    
    private void Start()
    {
        gameObject.SetActive(streetData.streetActive);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Transition());
            //SceneManager.LoadScene(streetData.streetName);
        }
    }

    private IEnumerator Transition()
    {
        Fader fader = FindObjectOfType<Fader>();
        
        yield return fader.FadeOut(fadeOutTime);
        
        yield return SceneManager.LoadSceneAsync(streetData.streetName);
        
        yield return new WaitForSeconds(fadeWaitTime);
        fader.FadeIn(fadeInTime);
    }
        
}
