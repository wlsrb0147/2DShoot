using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class DragonHomingBullet : MonoBehaviour
{
    public IObjectPool<GameObject> homing { get; set; }
    public float Speed= 3f;

    void release()
    {
        homing.Release(gameObject);
    }
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * Time.deltaTime * Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DragonPlayer"))
        {
            homing.Release(gameObject);
        }

        if (collision.gameObject.CompareTag("DragonLazer"))
        {
            homing.Release(gameObject);
            ScoreSceneText.score[5] += 2;
        }
    }

    private void OnBecameInvisible()
    {
        homing.Release(gameObject);
    }
}

