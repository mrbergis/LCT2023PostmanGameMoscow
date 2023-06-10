using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointMaillLogic : MonoBehaviour
{
    [SerializeField] private WayData wayData;

    [SerializeField] private StreetData streetData;
    
    [SerializeField] private GameObject way;
    [SerializeField] private GameObject marka;

    public string sceneName;


    private void Start()
    {
        if (wayData.weaponActive)
        {
            way.gameObject.SetActive(true);
            marka.gameObject.SetActive(false);

            if (streetData)
            {
                if (!streetData.streetActive)
                {
                    way.gameObject.SetActive(false);
                    marka.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            way.gameObject.SetActive(false);
            marka.gameObject.SetActive(true);
        }
    }

    public void MarkaActive()
    {
        wayData.weaponActive = false;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName); // Загрузка указанной сцены
    }
}
