using UnityEngine;

public class DragonFake : MonoBehaviour
{

    public GameObject bullet;

    public Transform[] fake;
    public Transform pos;

    // Update is called once per frame

    private void OnEnable()
    {
        if (pos != null)
        {
            for (int i = 0; i < fake.Length; i++)
            {
                GameObject v = Instantiate(bullet, fake[i].position, Quaternion.identity);
            }
        }

    }
    public void setDamage(int atk)
    {
        DragonBossHp.BossHp -= atk;

        if (DragonBossHp.BossHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
