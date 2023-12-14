using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMonster_Rush : MonoBehaviour
{
    Transform pos;
    Rigidbody2D rb;
    public float speed = 4f;
    public float MaxSpeed = 20f;
    public int score;

    public GameObject effect;
    // Start is called before the first frame update

    void Start()
    {
        pos = GameObject.FindGameObjectWithTag("DragonPlayer").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rotate();
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.magnitude < MaxSpeed)
        {
            rb.AddForce(transform.up * 2);
        }


        if (rb.velocity.magnitude > MaxSpeed)
        {
            rb.velocity = rb.velocity.normalized * MaxSpeed;
        }

    }

    private void OnBecameInvisible()
    {
        Invoke("delay", 0.2f);
    }

    void delay()
    {
        rotate();
        rb.velocity = transform.up * rb.velocity.magnitude;
    }

    void rotate()
    {
        if (pos != null) // 플레이어가 죽지 않았을 때
        {
            Quaternion angle = Quaternion.identity;
            Vector2 angleVec = new Vector2(pos.position.x - transform.position.x, pos.position.y - transform.position.y);
            angle.eulerAngles = new Vector3(0, 0, -Mathf.Atan2(angleVec.x, angleVec.y) * Mathf.Rad2Deg);
            transform.rotation = angle;
        }
    }

    private void OnDestroy()
    {
        ScoreSceneText.score[5] += ScoreSceneText.score[5];
        if (GameObject.FindGameObjectWithTag("DragonLazer") == null)
        {
            DragonGage.gage += 0.06f;
        }

        if (GameObject.FindGameObjectWithTag("DragonPlayer") != null)
        {
            GameObject v = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(v, 0.5f);
        }
    }
}
