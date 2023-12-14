using Unity.Mathematics;
using UnityEngine;

public class DragonPlayer : MonoBehaviour
{
    public GameObject fake1;
    public GameObject fake2;
    public GameObject boss;
    public GameObject clear;
    public static int x = 0;
    AudioSource ads;


    Rigidbody2D rb;
    public float speed = 2;
    public float RotSpeed = 6f;
    public int attacktype = 1;
    public int tempAttackType;
    Animator ani;

    float MoveX;
    float MoveY;

    //   public GameObject bullet;
    public Transform pos;
    public Transform PlayerPos;

    public GameObject Spear;
    public GameObject Death;
    public GameObject Lazer;
    public GameObject UI;
    public GameObject Power;

    float timer = 0;
    float timer2 = 0;
    public int ShootCycle;

    bool AttackOn = false;
    public bool PowerOverwhelming = false;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        fake1.SetActive(false);
        fake2.SetActive(false);
        ads = GetComponent<AudioSource>();

        ScoreSceneText.score[5] = 0;
        Dragontime.timeLeft = 61;
        DragonGage.gage = 0;
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Spear.SetActive(false);
        Lazer.SetActive(false);
        UI.SetActive(true);

        if (GameObject.FindWithTag("DragonGameOver") != null)
        {
            GameObject.FindWithTag("DragonGameOver").SetActive(false);
        }
        if (GameObject.FindWithTag("DragonGameClear") != null)
        {
            GameObject.FindWithTag("DragonGameClear").SetActive(false);
        }
        if (GameObject.Find("DefeatText") != null)
        {
            GameObject.Find("DefeatText").SetActive(false);
        }

        Invoke("Load", 0.1f);

    }
    void Load()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("DragonLazer") != null)
        {
            if (DragonGage.gage > 0)
            {
                DragonGage.gage -= 0.4f * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.Z))
        {
            attacktype = 1;
        }
        if (Input.GetKey(KeyCode.X))
        {
            attacktype = 2;
        }
        if (Input.GetKey(KeyCode.C))
        {
            if (DragonGage.gage == 1)
            {
                if (attacktype != 3)
                {
                    timer = 0;
                    tempAttackType = attacktype;
                    attacktype = 3;
                }
            }
        }

        if (AttackOn == false)
        {
            switch (attacktype)
            {
                case 1:
                    if (timer2 * 180 > (ShootCycle))

                    {
                        if (Input.GetKey(KeyCode.Space))
                        {
                            GameObject bullet = DragonObjectPooling.instance.player.Get();
                            bullet.transform.rotation = PlayerPos.rotation;
                            bullet.transform.position = pos.position;
                            timer2 = 0;
                        }
                    }
                    break;
                case 2:
                    if (Input.GetKey(KeyCode.Space))
                    {
                        if (timer > 0.8f)
                        {
                            Spear.SetActive(true);
                            Invoke("SpearDisable", 0.75f);
                            timer = 0;
                        }
                    }
                    break;
                case 3:
                    if (GameObject.FindGameObjectWithTag("DragonLazer") == null)
                    {
                        Lazer.SetActive(true);
                        AttackOn = true;
                        Invoke("LazerDisable", 2.5f);
                        timer = 0;
                    }
                    break;
                default:
                    attacktype = 1;
                    break;
            }
        }
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PowerOverwhelming = !PowerOverwhelming;
            
        }

        if (PowerOverwhelming)
        {
            Power.SetActive(true);
        }
        else
            Power.SetActive(false);


    }
    void SpearDisable()
    {
        Spear.SetActive(false);
    }

    void LazerDisable()
    {
        Lazer.SetActive(false);
        AttackOn = false;
        attacktype = tempAttackType;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(MoveX, MoveY);

        if (MoveX == 0 && MoveY == 0)
        {
            ani.SetBool("Move", false);
        }
        else
        {
            ani.SetBool("Move", true);
        }

        if (move.magnitude > 1)
        {
            move = move.normalized;
        }

        if (Input.GetKey(KeyCode.LeftShift)) // ����
        {
            rotate2(MoveX, MoveY);
            rb.velocity = move * speed;
        }

        else
        {
            rotate(MoveX, MoveY);
            rb.velocity = move * speed;
        }



        if (MoveX == 0 && MoveY == 0)
        {
            rb.velocity = Vector3.zero;
        }

        if (transform.position.x <= -118.5)
        {
            transform.position = new Vector3(-118.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= 118.5)
        {
            transform.position = new Vector3(118.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.y <= -75)
        {
            transform.position = new Vector3(transform.position.x, -75f, transform.position.z);
        }
        if (transform.position.y >= 75)
        {
            transform.position = new Vector3(transform.position.x, 75, transform.position.z);
        }
        if (x == 1)
        {
            Invoke("GameClear", 2);
            GetComponent<AudioSource>().Stop();
        }

    }

    void GameClear()
    {
        clear.SetActive(true);
    }

    void rotate(float x, float y)
    {
        if (x == 0 && y == 0) { return; }
        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = new Vector3(0, 0, -Mathf.Atan2(x, y) * Mathf.Rad2Deg);

        //eulerAngles(x,y,z), xyz ���� ȸ���� ����
        // atan2(x,y) = ź��Ʈ y/x���� ������ rad��
        // rad2deg = rad�� ������ �� ��׸��� ��ȯ

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, RotSpeed * Time.deltaTime);
        // Slerp(���簢��, ��ȯ�� ����, ���ӵ�)
    }

    void rotate2(float x, float y)
    {
        if (x == 0 && y == 0) { return; }
        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = new Vector3(0, 0, 180 - Mathf.Atan2(x, y) * Mathf.Rad2Deg);

        //eulerAngles(x,y,z), xyz ���� ȸ���� ����
        // atan2(x,y) = ź��Ʈ y/x���� ������ rad��
        // rad2deg = rad�� ������ �� ��׸��� ��ȯ

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, RotSpeed * Time.deltaTime);
        // Slerp(���簢��, ��ȯ�� ����, ���ӵ�)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PowerOverwhelming)
        {
            if (collision.CompareTag("DragonMonsterRot") || collision.CompareTag("DragonMonsterChase") || collision.CompareTag("DragonMonsterRush") || collision.CompareTag("Dragonbullet")
                    || collision.CompareTag("DragonBoss") || collision.CompareTag("DragonBossRush") || collision.CompareTag("DragonBossPT6") || collision.CompareTag("DragonBossDeath")
                    || collision.CompareTag("DragonBulletFake"))
            {
                Destroy(gameObject);
            }
        }
    }

   

    private void OnDestroy()
    {
        GameObject v = Instantiate(Death, transform.position, quaternion.identity);
        Destroy(v, 0.4f);
    }


}
