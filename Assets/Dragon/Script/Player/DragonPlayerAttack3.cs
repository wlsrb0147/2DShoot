using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPlayerAttack3 : MonoBehaviour
{
    public Transform pos;
    public int atk = 10;
    // Start is called before the first frame update

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("DragonPlayer") != null)
        {
            transform.position = pos.position;
            transform.rotation = pos.rotation;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
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
        if (collision.CompareTag("DragonFake"))
        {
            ScoreSceneText.score[5] += 24;
            collision.GetComponent<DragonFake>().setDamage(atk);
        }
        if (collision.CompareTag("DragonBoss"))
        {
            ScoreSceneText.score[5] += 24;
            collision.GetComponent<DragonBossHp>().setDamage(atk);
        }
        if (collision.CompareTag("DragonBossRush"))
        {
            collision.GetComponent<DragonMonsterHp>().setDamage(atk);
        }
        if (collision.CompareTag("DragonBossPT6"))
        {
            Destroy(collision.gameObject);
        }
    }

}
