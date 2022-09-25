using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public static Tank instance;
    private void Awake()
    {
        instance = this;
    }
}
