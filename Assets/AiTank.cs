﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiTank : MonoBehaviour
{
    public float attackRange = 10f;
    private float speed = 3f;
    public GameObject missile;
    public Transform firePos;
    private float afterFireDelay = 1f;

    IEnumerator Start()
    {
        while (true)
        {
            // 우리탱크로 이동.
            while (IsAttackableRange()== false) //이동
            {
                Vector3 dir = GetTargetDir(); // 크기를 1로 만듬(방향만 사용)
                transform.Translate(dir * speed * Time.deltaTime, Space.World);
                transform.forward = dir;
                yield return null;
            }

            // 우리탱크로 이동 했으니 미사일을 발사
            yield return null;

            transform.forward = GetTargetDir();
            var newMissile = Instantiate(missile);
            newMissile.transform.position = firePos.position;
            newMissile.transform.forward = transform.forward;
            yield return new WaitForSeconds(afterFireDelay);
        }
    }

    private Vector3 GetTargetDir()
    {
        Vector3 dir = Tank.instance.transform.position -
                            transform.position;
        dir.Normalize();
        return dir;
    }

    private bool IsAttackableRange()
    {
        var distance = Vector3.Distance(Tank.instance.transform.position
            , transform.position);
        return attackRange > distance;
    }
}
