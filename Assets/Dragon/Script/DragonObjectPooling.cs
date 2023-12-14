using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DragonObjectPooling : MonoBehaviour
{

    public static DragonObjectPooling instance;

    public int homingDefault = 500;
    public int homingMax = 1000;

    public int playerDefault = 200;
    public int playerMax = 400;

    public GameObject bulletPrefab;
    public GameObject playerBulletPrefab;

    public IObjectPool<GameObject> homing { get; private set; }
    public IObjectPool<GameObject> player { get; private set; }


    private void Awake()
    {
        if (instance == null)
            instance = this;
        Init();
    }

    private void Init()
    {
        // homing
        {
            homing = new ObjectPool<GameObject>
            (Createhoming, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false, homingDefault, homingMax);

            // ObjectPool ( 생성함수, get, release,bool,1destroy, 상시용량, 최대사이즈)
            // 미리 오브젝트 생성 해놓기
            for (int i = 0; i < homingDefault; i++)
            {
                DragonHomingBullet homingBullet = Createhoming().GetComponent<DragonHomingBullet>();
                homingBullet.homing.Release(homingBullet.gameObject);
            }
        }

        // player
        {
            player = new ObjectPool<GameObject>
                       (Createplayer, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false, playerDefault, playerMax);

            for (int i = 0; i < playerDefault; i++)
            {
                DragonBullet playerBullet = Createplayer().GetComponent<DragonBullet>();
                playerBullet.playerbullet.Release(playerBullet.gameObject);
            }
        }


    }

    // 생성
    private GameObject Createhoming()
    {
        GameObject Items = Instantiate(bulletPrefab); // 풀 고 = 불릿 프리팹 생성한것
        Items.GetComponent<DragonHomingBullet>().homing = this.homing; // 호밍불릿에 여기 풀 넣음
        return Items;  // 생성 완료, 제출
    }

    private GameObject Createplayer()
    {
        GameObject Items = Instantiate(playerBulletPrefab); // 풀 고 = 불릿 프리팹 생성한것
        Items.GetComponent<DragonBullet>().playerbullet = this.player; // 호밍불릿에 여기 풀 넣음
        return Items;  // 생성 완료, 제출
    }

    // 사용
    private void OnTakeFromPool(GameObject Items)
    {
        Items.SetActive(true); //활성화, 빌려줌
    }

    // 반환
    private void OnReturnedToPool(GameObject Items)
    {
        Items.SetActive(false); // 비활성화 , 돌려줌
    }

    // 삭제
    private void OnDestroyPoolObject(GameObject Items)
    {
        Destroy(Items); // 추가로 생성된 것 파괴
    }
}