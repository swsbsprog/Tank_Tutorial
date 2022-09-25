﻿using UnityEngine;

public class Cursor2 : MonoBehaviour 
{    
	void Update () 
	{
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, 1 << LayerMask.NameToLayer("Ground")))
        {
            transform.position = hit.point;
        }
	}
}
