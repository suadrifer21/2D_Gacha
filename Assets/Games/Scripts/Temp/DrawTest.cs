using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTest : MonoBehaviour
{
    public DrawTable drawTable;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameEntity gameEntity = drawTable.GetItem();
            Debug.Log(gameEntity.Name);
        }
    }
}
