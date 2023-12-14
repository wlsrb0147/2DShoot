using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragonBossHp : MonoBehaviour
{
    public static int BossHp;
    public static int MaxHP;

    public int bossHp;

    private void Awake()
    {
        BossHp = bossHp;
        MaxHP = bossHp;
    }
    public void setDamage(int atk)
    {
        BossHp -= atk;

        if (BossHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
