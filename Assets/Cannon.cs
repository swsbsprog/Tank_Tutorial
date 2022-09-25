using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject shell;
    public Transform firePos;
    public Transform fireRot;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(shell, firePos.position
                , fireRot.rotation);
        }
    }
}
