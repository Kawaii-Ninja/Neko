using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor : MonoBehaviour
{
    private void Update()
    {
        MousePosTwo();
    }

    private void MousePosTwo()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(worldMousePosition.x, worldMousePosition.y, transform.position.z);
    }
}
