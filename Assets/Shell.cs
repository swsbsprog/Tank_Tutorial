using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public ParticleSystem explosion;
    public float attackRange = 3;
    public int damage = 30;
    private void OnTriggerEnter(Collider other)
    {
        print(other);
        Destroy(gameObject);

        explosion.transform.parent = null;
        explosion.Play();

        //// 주변에 있는 탱크에 데미지를 주자.
        //// 방법1 (List foreach)
        //BaseTank.tanks.ForEach(tank =>
        //{
        //    float distance = Vector3.Distance(
        //        tank.transform.position, transform.position);
        //    if (distance < attackRange)
        //        tank.Damage(damage);
        //});


        // 방법2 (일반적인 foreach)
        foreach (var tank in BaseTank.tanks)
        {
            float distance = Vector3.Distance(
                tank.transform.position, transform.position);
            if (distance < attackRange)
                tank.Damage(damage);
        }
    }
}
