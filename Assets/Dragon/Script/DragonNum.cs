using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonNum : MonoBehaviour
{
    public Text text;
    GameObject[][] MonsterCount = new GameObject[3][];
    int[] x = new int[3];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            tag = countnum(i);
            MonsterCount[i] = GameObject.FindGameObjectsWithTag(tag);
            x[i] = MonsterCount[i].Length;
            x[i] = x[i] - 1;
        }
        text.text = "ºí·çµå·¡°ï : " + x[0] + " / 50\n" +
                    "·¹µåµå·¡°ï : " + x[1] + " / 10\n" +
                    "ÆÛÇÃµå·¡°ï : " + x[2] + " / 3";

    }

    string countnum(int num)
    {
        switch (num)
        {
            case 0:
                tag = "DragonMonsterRot";
                break;
            case 1:
                tag = "DragonMonsterRush";
                break;
            case 2:
                tag = "DragonMonsterChase";
                break;
            default:
                tag = "DragonMonster";
                break;
        }
        return tag;
    }
}
