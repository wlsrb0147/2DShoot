using Unity.VisualScripting;
using UnityEngine;

public class DragonRed : MonoBehaviour
{
    float timer;
    Transform pos;
    Rigidbody2D rb;
    Vector2 target;
    int x;
    public float speed = 10;
    // Start is called before the first frame update
    AudioSource ads;
    public AudioClip pt;
    void Start()
    {
        x = 0;
        pos = GameObject.FindGameObjectWithTag("DragonPlayer").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        Invoke("Invisible", 7);
        ads = GetComponent<AudioSource>();
    }

    void Invisible()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (x == 0 && timer > 2)
        {
            target = target.normalized;
            rb.AddForce(target * speed, ForceMode2D.Impulse);
            x++;
            ads.PlayOneShot(pt);
        }
        else if (timer < 2)
        {
            if (pos != null)
            {

                target = new Vector2(pos.position.x - transform.position.x, pos.position.y - transform.position.y);
                Vector3 targetangle = new Vector3(0, 0, -Mathf.Atan2(target.x, target.y) * Mathf.Rad2Deg);
                transform.rotation = Quaternion.Euler(targetangle);
            }
        }

        if (GameObject.FindGameObjectWithTag("DragonBoss") == null)
        {
            Destroy(gameObject);
        }
    }

  
    private void OnDestroy()
    {
        ScoreSceneText.score[5] += 50;
    }
}
