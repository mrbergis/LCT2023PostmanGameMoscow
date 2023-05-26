using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player", order = 0)]
public class PlayerDataSO : ScriptableObject
{
    public Transform playerPosition;

    public void SetPlayerPosition(float[] position)
    {
        playerPosition.transform.position = new Vector3(position[0], position[1], position[2]);
    }

    public float[] ConvertTransformToArray()
    {
        var position = new float[3];
        position[0] = playerPosition.transform.position.x;
        position[1] = playerPosition.transform.position.y;
        position[2] = playerPosition.transform.position.z;
        return position;
    }
}
