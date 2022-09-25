using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
