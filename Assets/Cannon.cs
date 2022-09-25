using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject shell;
    public Transform firePos;
    public Transform fireRot;
    [SerializeField]
    CannonController cannon;
    void Update()
    {
        cannon.SetTargetWithAngle(
            Cursor.instance.transform.position, 45);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject p = Instantiate(shell, firePos.position, Quaternion.identity);
            p.GetComponent<Rigidbody>().velocity = cannon.turret.up * cannon.currentSpeed;
            //p.transform.forward = cannon.turret.up;
        }
    }
}
