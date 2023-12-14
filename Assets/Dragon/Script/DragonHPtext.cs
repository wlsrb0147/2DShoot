using UnityEngine;
using UnityEngine.UI;

public class DragonHPtext : MonoBehaviour
{
    public Text text;
    float percentage;
    // Start is called before the first frame update

    private void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        text.text = DragonBossHp.BossHp + "/" + DragonBossHp.MaxHP;

        percentage = DragonBossHp.BossHp / (float)DragonBossHp.MaxHP;
        GameObject.FindWithTag("DragonHp").GetComponent<Slider>().value = percentage;


    }
}
