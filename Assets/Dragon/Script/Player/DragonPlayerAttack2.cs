using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DragonPlayerAttack2 : MonoBehaviour
{
    public Transform pos;
    public float SpearSpeed = 20f;
    public int atk = 500;
    // Start is called before the first frame update
    private void OnEnable()
    {
        transform.position = pos.position;
        transform.rotation = pos.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * SpearSpeed); ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* if (collision.CompareTag("Monster"))
        {
            collision.GetComponent<MonsterHp>().setDamage(atk);
        }*/
        if (collision.CompareTag("DragonMonsterRot"))
        {
            collision.GetComponent<DragonMonsterHp>().setDamage(atk);

        }
        if (collision.CompareTag("DragonMonsterChase"))
        {
            collision.GetComponent<DragonMonsterHp>().setDamage(atk);

        }
        if (collision.CompareTag("DragonMonsterRush"))
        {
            collision.GetComponent<DragonMonsterHp>().setDamage(atk);
        }
        if (collision.CompareTag("DragonBossRush"))
        {
            collision.GetComponent<DragonMonsterHp>().setDamage(atk);
        }
        if (collision.CompareTag("DragonFake"))
        {
            collision.GetComponent<DragonFake>().setDamage(atk);
        }
        if (collision.CompareTag("DragonBoss"))
        {
            if (GameObject.FindGameObjectWithTag("DragonLazer") == null)
            {
                DragonGage.gage += 0.1f;
            }
            ScoreSceneText.score[5] += 60;
            collision.GetComponent<DragonBossHp>().setDamage(atk);
        }
    }
}
