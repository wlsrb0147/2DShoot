using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;

public class DragonCreateHoming : MonoBehaviour
{
    public Transform pos;
    public GameObject bullet;
    public float BulletCycle;
    public Transform targetPos;
    public float Shootdistance = 14;

    void Start()
    { InvokeRepeating("CreateBullet", 0, BulletCycle); }
    void CreateBullet()
    {
        if (GameObject.FindGameObjectWithTag("DragonPlayer") != null) // 플레이어가 죽지 않았을 때
        {


            targetPos = GameObject.FindGameObjectWithTag("DragonPlayer").transform;

            if (Vector3.Distance(targetPos.position, transform.position) < Shootdistance) // 일정거리 안에서만 총알생성
            {
                GameObject bullet = DragonObjectPooling.instance.homing.Get();
                bullet.transform.rotation = quaternion.identity;
                bullet.transform.position = pos.position;
                
                Quaternion angle = Quaternion.identity;
                Vector2 angleVec = new Vector2(targetPos.position.x - bullet.transform.position.x, targetPos.position.y - bullet.transform.position.y);
                angle.eulerAngles = new Vector3(0, 0, -Mathf.Atan2(angleVec.x, angleVec.y) * Mathf.Rad2Deg);
                bullet.transform.rotation = angle;

            }
        }
    }
}
