using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DragonMonster_Chase : MonoBehaviour
{
    Transform pos;
    public float Speed;
    Rigidbody2D rb;
    public int score;

    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        pos = GameObject.FindGameObjectWithTag("DragonPlayer").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rotate();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("DragonPlayer") != null)
        {
        rotate();
        transform.Translate(0, Speed * Time.deltaTime, 0);
        }
    }

    private void OnBecameInvisible()
    {
        transform.Translate(0, Speed * 2 * Time.deltaTime, 0);
    }

    void rotate()
    {
        Quaternion angle = Quaternion.identity;
        Vector2 angleVec = new Vector2(pos.position.x - transform.position.x, pos.position.y - transform.position.y);
        angle.eulerAngles = new Vector3(0, 0, -Mathf.Atan2(angleVec.x, angleVec.y) * Mathf.Rad2Deg);
        transform.rotation = angle;
    }
    private void OnDestroy()
    {
        ScoreSceneText.score[5] += score;
        if (GameObject.FindGameObjectWithTag("DragonLazer") == null)
        {
            DragonGage.gage += 0.2f;
        }

        if (GameObject.FindGameObjectWithTag("DragonPlayer") != null)
        {
            GameObject v = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(v, 0.5f);
        }
    }

}
