using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SocialPlatforms.Impl;

public class DragonBullet : MonoBehaviour
{
    public IObjectPool<GameObject> playerbullet { get; set; }
    public GameObject HitEffect;
    public float Speed = 4;
    public int atk = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        playerbullet.Release(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("DragonMonsterRot"))
        {
            collision.GetComponent<DragonMonsterHp>().setDamage(atk);
            playerbullet.Release(gameObject);
            GameObject effect = Instantiate(HitEffect, transform.position,transform.rotation);
            Destroy(effect, 1);
        }
        if (collision.CompareTag("DragonMonsterChase"))
        {
            collision.GetComponent<DragonMonsterHp>().setDamage(atk);
            playerbullet.Release(gameObject);
            GameObject effect = Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(effect, 1);
        }
        if (collision.CompareTag("DragonMonsterRush"))
        {
            collision.GetComponent<DragonMonsterHp>().setDamage(atk);
            playerbullet.Release(gameObject);
            GameObject effect = Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(effect, 1);
        }
        if (collision.CompareTag("DragonBossRush"))
        {
            collision.GetComponent<DragonMonsterHp>().setDamage(atk);
            playerbullet.Release(gameObject);
            GameObject effect = Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(effect, 1);
        }
        if (collision.CompareTag("DragonFake"))
        {
            collision.GetComponent<DragonFake>().setDamage(atk);
            playerbullet.Release(gameObject);
            GameObject effect = Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(effect, 1);
        }
        if (collision.CompareTag("DragonBoss"))
        {
            if (GameObject.FindGameObjectWithTag("DragonLazer") == null)
            {
                DragonGage.gage += 0.005f;
            }
            ScoreSceneText.score[5] += 3;
            collision.GetComponent<DragonBossHp>().setDamage(atk);
            playerbullet.Release(gameObject);
            GameObject effect = Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(effect, 1);
            
        }
    }

}
