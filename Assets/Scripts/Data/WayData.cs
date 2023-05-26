using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WayData", menuName = "Data/Way", order = 0)]
public class WayData : ScriptableObject
{
    public string wayName;
    public bool weaponActive = true;
}
