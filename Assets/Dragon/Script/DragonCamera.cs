using UnityEngine;

public class Dragoncamera : MonoBehaviour
{
    public Transform player;
    public GameObject boss;
    float timer;
    int r;

    float x;
    float y;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        z = transform.position.z;
        Invoke("SetResolution", 0.1f);
    }


    /* �ػ� �����ϴ� �Լ� */
    public void SetResolution()
    {
        int setWidth = 1920; // ����� ���� �ʺ�
        int setHeight = 1080; // ����� ���� ����
        Screen.SetResolution(setWidth, setHeight, true); // SetResolution �Լ� ����� ����ϱ�

    }


    // Update is called once per frame
    void Update()
    {
        if (player != null) // �÷��̾ ���� �ʾ��� ��
        {
            if (DragonMonster_Boss.pattern != 6)
            {
                if ((player.position.x >= -111) && (player.position.x <= 111))
                {
                    x = player.transform.position.x;
                }

                if ((player.position.y <= 71) && (player.position.y >= -71))
                {
                    y = player.transform.position.y;
                }
                transform.position = new Vector3(x, y, z);
            }
        }

        if (DragonMonster_Boss.pattern == 3 && r == 0)
        {
            timer += Time.deltaTime;
            if (timer < 1.5f)
            {
                transform.position = new Vector3(boss.transform.position.x, boss.transform.position.y,-10);

            }
            else
            {
                r++;
            }
        }
        else if (DragonMonster_Boss.pattern != 3)
        {
            r = 0;
            timer = 0;
        }
            
    }


}
