using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        var lookAtPos = target.position;
        lookAtPos.y = transform.position.y;
        transform.LookAt(lookAtPos);
    }
}
