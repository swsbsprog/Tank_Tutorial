using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public ParticleSystem explosion;
    private void OnTriggerEnter(Collider other)
    {
        print(other);
        Destroy(gameObject);

        explosion.transform.parent = null;
        explosion.Play();
    }
}
