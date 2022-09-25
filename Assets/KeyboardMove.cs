using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMove : MonoBehaviour
{
    private float speed = 5f;

    void Update()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W)) dir.z = 1;
        if (Input.GetKey(KeyCode.A)) dir.x = -1;
        if (Input.GetKey(KeyCode.S)) dir.z = -1;
        if (Input.GetKey(KeyCode.D)) dir.x = 1;

        if (dir.sqrMagnitude != 0) //dir != Vector3.zero
        {
            transform.Translate(speed * Time.deltaTime * dir
                , Space.World);
            transform.forward = dir;
        }
    }
}
