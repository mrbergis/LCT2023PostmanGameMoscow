using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StreetData", menuName = "Data/Streety", order = 0)]
public class StreetData : ScriptableObject
{
    public string streetName;
    public bool streetActive = true;
}
