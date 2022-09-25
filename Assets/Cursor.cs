using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Vector3 mousePosition;
    public LayerMask mask;
    void Update()
    {
        mousePosition = Input.mousePosition;
        var ray = Camera.main.ScreenPointToRay(mousePosition);
        //var checkLayer = 1 << LayerMask.NameToLayer("Ground");
        Physics.Raycast(ray, out var hitInfo, mask);
        transform.position =hitInfo.point;
    }
}
