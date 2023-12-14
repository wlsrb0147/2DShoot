using Unity.VisualScripting;
using UnityEngine;

public class DragonRealBullet : MonoBehaviour
{
    Transform pos;
    public float Speed = 7;
    // Start is called before the first frame update

    private void Start()
    {
        pos = GameObject.FindGameObjectWithTag("DragonPlayer").GetComponent<Transform>();
        Vector2 target = new Vector2(pos.position.x - transform.position.x, pos.position.y - transform.position.y);
        Vector3 targetangle = new Vector3(0, 0, -Mathf.Atan2(target.x, target.y) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Euler(targetangle);
    }


    void Update()
    {

        transform.Translate(Vector2.up * Speed * Time.deltaTime);
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
