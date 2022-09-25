using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiTank : MonoBehaviour
{
    public float attackRange = 10f;
    private float speed = 3f;

    IEnumerator Start()
    {
        while (true)
        {
            // 우리탱크로 이동.
            while (IsAttackableRange()== false) //이동
            {
                Vector3 dir = Tank.instance.transform.position -
                    transform.position;
                dir.Normalize(); //-> // 크기를 1로 만듬
                transform.Translate(dir * speed * Time.deltaTime, Space.World);
                transform.forward = dir;
                yield return null;
            }

            // 우리탱크로 이동 했으니 미사일을 발사
            yield return null;
        }
    }

    private bool IsAttackableRange()
    {
        var distance = Vector3.Distance(Tank.instance.transform.position
            , transform.position);
        return attackRange > distance;
    }
}
