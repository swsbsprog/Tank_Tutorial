using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Vector3 mousePosition;
    void Update()
    {
        mousePosition = Input.mousePosition;
        var ray = Camera.main.ScreenPointToRay(mousePosition);
        //var checkLayer = LayerMask.NameToLayer("Ground");
        Physics.Raycast(ray, out var hitInfo);
        transform.position =hitInfo.point;
    }
}
