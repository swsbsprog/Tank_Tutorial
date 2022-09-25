using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiTank : BaseTank
{
    public float attackRange = 10f;
    private float speed = 3f;
    public GameObject missile;
    public Transform firePos;
    private float afterFireDelay = 1f;
    public NavMeshAgent agent;
    public Transform turretTr;

    new IEnumerator Start()
    {
        base.Start();
        while (true)
        {
            // 우리탱크로 이동.
            agent.enabled = true;
            while (IsAttackableRange() == false) //이동
            {
                agent.destination = Tank.instance.transform.position;
                yield return null;
            }
            agent.enabled = false;

            // 포신 플레이어를 향하게 하기
            while (IsTowardToPlayer() == false)
            {
                var targetDir = GetTargetDir();
                //float multiply = 오른쪽인지 왼쪽인지 가까운 쪽으로;
                //turretTr.Rotate(axis, rotateAngle);

                toAngle = Vector3.Angle(targetDir, Vector3.up);
                var speed = toAngle > 0 ? rotateSpeed : -rotateSpeed;
                turretTr.Rotate(axis, speed);

                yield return null;
            }

            // 우리탱크로 이동 했으니 미사일을 발사
            //transform.forward = GetTargetDir();
            var newMissile = Instantiate(missile);
            newMissile.transform.position = firePos.position;
            newMissile.transform.forward = turretTr.forward;
            yield return new WaitForSeconds(afterFireDelay);
        }
    }

    public float angle;
    public float toAngle;
    public float minAngle = 1;
    public float rotateSpeed = 1;
    public Vector3 axis = new Vector3(0, 1, 0);
    private bool IsTowardToPlayer()
    {
        var targetDir = GetTargetDir();
        angle = Vector3.Angle(turretTr.forward, targetDir);
        return angle < minAngle;
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
