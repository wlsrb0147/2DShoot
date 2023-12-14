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

            // ObjectPool ( �����Լ�, get, release,bool,1destroy, ��ÿ뷮, �ִ������)
            // �̸� ������Ʈ ���� �س���
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

    // ����
    private GameObject Createhoming()
    {
        GameObject Items = Instantiate(bulletPrefab); // Ǯ �� = �Ҹ� ������ �����Ѱ�
        Items.GetComponent<DragonHomingBullet>().homing = this.homing; // ȣ�ֺҸ��� ���� Ǯ ����
        return Items;  // ���� �Ϸ�, ����
    }

    private GameObject Createplayer()
    {
        GameObject Items = Instantiate(playerBulletPrefab); // Ǯ �� = �Ҹ� ������ �����Ѱ�
        Items.GetComponent<DragonBullet>().playerbullet = this.player; // ȣ�ֺҸ��� ���� Ǯ ����
        return Items;  // ���� �Ϸ�, ����
    }

    // ���
    private void OnTakeFromPool(GameObject Items)
    {
        Items.SetActive(true); //Ȱ��ȭ, ������
    }

    // ��ȯ
    private void OnReturnedToPool(GameObject Items)
    {
        Items.SetActive(false); // ��Ȱ��ȭ , ������
    }

    // ����
    private void OnDestroyPoolObject(GameObject Items)
    {
        Destroy(Items); // �߰��� ������ �� �ı�
    }
}