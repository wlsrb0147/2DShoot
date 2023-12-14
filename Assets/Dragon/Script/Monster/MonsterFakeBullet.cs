using UnityEngine;

public class MonsterFakeBullet : MonoBehaviour
{
    Transform pos;
    Vector2 go;
    // Start is called before the first frame update

    private void Awake()
    {
        pos = GameObject.FindGameObjectWithTag("DragonPlayer").GetComponent<Transform>();
    }

    void Start()
    {
        go = pos.position - transform.position;
        go = go.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(go * 3 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DragonPlayer"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("DragonLazer"))
        {
            Destroy(gameObject);
            ScoreSceneText.score[5] += 10;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
