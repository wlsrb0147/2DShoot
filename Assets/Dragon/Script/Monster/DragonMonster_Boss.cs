using UnityEngine;
using UnityEngine.UI;

public class DragonMonster_Boss : MonoBehaviour
{
    public static int pattern = 4;

    public Transform pos;
    public Transform[] shoot;

    public Transform[] AxisX;
    public Transform[] AxisY;
    public GameObject PT1bullet;
    public GameObject PT6bullet;
    public GameObject RedDragon;
    public Transform[] red;
    public GameObject camera;
    public GameObject bar;
    int clean;
    public GameObject deadeffect;
    public GameObject deathpattern;
    public Transform deathform;

    int nowhp; // 3페 시작시 체력
    double percentage;

    public Text text;

    float timer = 0;
    float counter; // 지속시간
    int i;
    int j = 0;

    bool off = false;

    public float[] PTcount = new float[7];
    public float[] PTcycle = new float[7];

    public GameObject[] fake;

    AudioSource ads;
    public AudioClip[] pt;
    public AudioClip entry;

    

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        clean = 0;
        camera.SetActive(false);
        text.text = "";
        ads = GetComponent<AudioSource>();
        ads.PlayOneShot(entry);
    }


    private void OnEnable()
    {
        
        if (pos != null)
        {
            transform.position = new Vector3(pos.position.x + 11, pos.position.y, pos.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pos != null)
        {
            if (j == 0) // 패턴 2에서 j가 1값이 나옴
            {
                Vector2 target = new Vector2(pos.position.x - transform.position.x, pos.position.y - transform.position.y);
                Vector3 targetangle = new Vector3(0, 0, -Mathf.Atan2(target.x, target.y) * Mathf.Rad2Deg);
                transform.rotation = Quaternion.Euler(targetangle);
            }
            camera.transform.rotation = Quaternion.Euler(0, 0, 90);

            if (pattern == 2 || pattern == 4)
            {
                transform.Translate(Vector2.up * 2f * Time.deltaTime);
            }

            if (pattern != 3)
            {
                camera.SetActive(false);
            }

            timer += Time.deltaTime;

            switch (pattern)
            {
                case 1:
                    //if (Vector2.Distance(pos.position, transform.position) > 6)
                    if (true)
                    { //ON 기본상태 = false

                        if (!off)
                        {
                            off = !off; // off를 on으로 만듦
                            Invoke("HyperDash", 2); // 여기서 j가 1이됨
                        }
                    }/*
                    else if (off) // 거리가 한번이라도 6 이상으로 갔다면 패턴 전까지 아무것도 안함
                    { }
                    else // 거리가 6이상으로 간적이 없다면 패턴 1
                    {
                        {
                            if (timer > PTcycle[pattern])
                            {
                                for (int i = 0; i < shoot.Length; i++)
                                {

                                    Vector2 aa11 = new Vector2(pos.position.x - shoot[i].position.x, pos.position.y - shoot[i].position.y);
                                    Vector3 aa22 = new Vector3(0, 0, -Mathf.Atan2(aa11.x - 60 + 60 * i, aa11.y - 60 + 60 * i) * Mathf.Rad2Deg); ;
                                    Instantiate(PT1bullet, shoot[i].position, Quaternion.Euler(aa22));
                                }
                                timer = 0;
                            }
                            if (counter > PTcount[pattern])
                            {
                                EndPattern();
                            }
                        }
                    }
                    counter += Time.deltaTime;*/
                    break;
                case 2:
                    if (timer > PTcycle[pattern])
                    {
                        for (int i = 0; i < shoot.Length; i++)
                        {

                            Vector2 aa11 = new Vector2(pos.position.x - shoot[i].position.x, pos.position.y - shoot[i].position.y);
                            Vector3 aa22 = new Vector3(0, 0, -Mathf.Atan2(aa11.x - 60 + 60 * i, aa11.y - 60 + 60 * i) * Mathf.Rad2Deg); ;
                            Instantiate(PT1bullet, shoot[i].position, Quaternion.Euler(aa22));
                            ads.PlayOneShot(pt[6]);

                        }
                        timer = 0;
                    }
                    if (counter > PTcount[pattern] && clean == 0)
                    {
                        counter += Time.deltaTime;
                        Invoke("EndPattern", 3);
                        clean++;
                    }
                    counter++;
                    break;
                case 3:
                    if (clean == 0)
                    {
                        nowhp = DragonBossHp.BossHp;
                        counter = PTcount[pattern];
                        camera.SetActive(true);
                        bar.GetComponent<Slider>().value = 1;
                        clean++;
                        ads.PlayOneShot(pt[3]);
                    }

                    percentage = (nowhp - DragonBossHp.BossHp) / (DragonBossHp.MaxHP * 0.1);

                    bar.GetComponent<Slider>().value = 1 - (float)percentage;


                    counter -= Time.deltaTime;
                    text.text = ((int)counter).ToString();

                    if (percentage > 1)
                    {
                        text.text = "";
                        EndPattern();
                    }
                    else if (counter <= 0 && clean ==1)
                    {
                        clean++;
                        GameObject v = Instantiate(deathpattern, deathform.position, shoot[0].rotation);
                        Destroy(v, 1.5f);
                        text.text = "";
                        EndPattern();
                        pattern = 3;
                    }


                    break;
                case 4:

                    if (timer > PTcycle[pattern] && clean == 0)
                    {
                        for (i = 0; i < 4; i++) // 패턴 1회 실행
                        {
                            Vector2 ins = new Vector2(red[i].position.x, red[i].position.y);
                            Vector2 rot = new Vector2(pos.position.x - ins.x, pos.position.y - ins.y);
                            Vector3 angle = new Vector3(0, 0, -Mathf.Atan2(rot.x, rot.y) * Mathf.Rad2Deg);

                            GameObject v = Instantiate(RedDragon, ins, Quaternion.Euler(angle));


                        }
                        timer = 0;
                        counter++;
                    }

                    if (counter == PTcount[pattern] && clean == 0)
                    {
                        Invoke("EndPattern", 3);
                        clean++;
                    }
                    break;
                case 5:
                    transform.position = new Vector3(pos.position.x + 20, pos.position.y + 20, transform.position.z);

                    if (i == 0)
                    {
                        i = Random.Range(1, 7);
                    }


                    if (timer > PTcycle[pattern] && clean == 0) // on,off 반복패턴
                    {
                        ads.PlayOneShot(pt[5]);
                        fake[i % 2].SetActive(true);
                        fake[(i + 1) % 2].SetActive(false);
                        i++;
                        counter++;
                        timer = 0;
                    }
                    if (counter == PTcount[pattern] && clean == 0)
                    {
                        i = 0;
                        fake[i % 2].SetActive(false);
                        fake[(i + 1) % 2].SetActive(false);

                        int x = Random.Range(1, 9);
                        switch (x)
                        {
                            case 1:
                                transform.position = new Vector3(pos.position.x + 9, pos.position.y, transform.position.z);
                                break;
                            case 2:
                                transform.position = new Vector3(pos.position.x + 7f, pos.position.y + 4.5f, transform.position.z);
                                break;
                            case 3:
                                transform.position = new Vector3(pos.position.x + 7f, pos.position.y - 4.5f, transform.position.z);
                                break;
                            case 4:
                                transform.position = new Vector3(pos.position.x - 9, pos.position.y, transform.position.z);
                                break;
                            case 5:
                                transform.position = new Vector3(pos.position.x - 7f, pos.position.y + 4.5f, transform.position.z);
                                break;
                            case 6:
                                transform.position = new Vector3(pos.position.x - 7f, pos.position.y - 4.5f, transform.position.z);
                                break;
                            case 7:
                                transform.position = new Vector3(pos.position.x, pos.position.y + 6, transform.position.z);
                                break;
                            case 8:
                                transform.position = new Vector3(pos.position.x, pos.position.y - 6, transform.position.z);
                                break;
                        }
                        Vector2 rot = new Vector2(pos.position.x - transform.position.x, pos.position.y - transform.position.y);
                        transform.eulerAngles = new Vector3(0, 0, -Mathf.Atan2(rot.x, rot.y) * Mathf.Rad2Deg);
                        Invoke("EndPattern", 3);
                        clean++;
                    }

                    break;
                case 6:
                    counter += Time.deltaTime; // 카운터에 시간이 필요했음
                    if (timer > PTcycle[pattern] && clean == 0)
                    {
                        ads.PlayOneShot(pt[6]);
                        for (int i = 0; i < AxisX.Length; i++)
                        {
                            GameObject v = Instantiate(PT6bullet, AxisX[i].position, Quaternion.Euler(0, 0, 90));
                            Destroy(v, 4);
                        }
                        for (int i = 0; i < AxisY.Length; i++)
                        {
                            GameObject v = Instantiate(PT6bullet, AxisY[i].position, Quaternion.Euler(0, 0, 180));
                            Destroy(v, 7);
                        }
                        timer = 0;
                    }

                    if (counter >= PTcount[pattern] && clean == 0)
                    {
                        transform.position = new Vector3(pos.position.x + 6, pos.position.y, pos.position.z);
                        Invoke("EndPattern", 3);
                        clean++;

                    }
                    break;
                default: break;
            }


        }
    }

    void HyperDash()
    {
        if (pos != null)
        {

            Vector2 target2 = new Vector2(pos.position.x - transform.position.x, pos.position.y - transform.position.y);
            target2 = target2.normalized;
            rb.AddForce(target2 * 8, ForceMode2D.Impulse);
            j = 1;
            Invoke("EndPattern", 3);
            clean = 0;
            ads.PlayOneShot(pt[1]);
        }
    }



    void EndPattern()
    {
        pattern++;
        if (pattern > 6)
        {
            pattern = 1;
        }
        counter = 0;
        clean = 0;
        off = false;
        j = 0;
        rb.velocity = Vector2.zero; // 패턴2에서 addforce 해줬기때문에 이걸 해줘야함
    }

    private void OnDestroy()
    {
        ScoreSceneText.score[5] += 2000;
        DragonPlayer.x = 1;
        GameObject v = Instantiate(deadeffect, transform.position, Quaternion.identity);
        Destroy(v, 1.6f);
        pattern = 1;
    }
}
