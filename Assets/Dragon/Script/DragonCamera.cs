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


    /* 해상도 설정하는 함수 */
    public void SetResolution()
    {
        int setWidth = 1920; // 사용자 설정 너비
        int setHeight = 1080; // 사용자 설정 높이
        Screen.SetResolution(setWidth, setHeight, true); // SetResolution 함수 제대로 사용하기

    }


    // Update is called once per frame
    void Update()
    {
        if (player != null) // 플레이어가 죽지 않았을 때
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
