using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragonMonsterHp : MonoBehaviour
{
    public int Hp;

    public void setDamage(int atk)
    {
        Hp -= atk;

        if(Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
