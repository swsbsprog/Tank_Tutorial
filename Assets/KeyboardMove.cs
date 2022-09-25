using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMove : MonoBehaviour
{
    private float speed = 5f;

    void Update()
    {
        Vector3 move = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W)) move.z = 1;
        if (Input.GetKey(KeyCode.A)) move.x = -1;
        if (Input.GetKey(KeyCode.S)) move.z = -1;
        if (Input.GetKey(KeyCode.D)) move.x = 1;
        transform.Translate(speed * Time.deltaTime * move);
    }
}
