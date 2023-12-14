using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class DragonMonsterCreate : MonoBehaviour
{
    int[] timer = new int[10];
    public int[] CreateTimer;
    public int[] percent;
    GameObject[][] MonsterCount = new GameObject[10][];
    public int[] MonsterNum;
    public GameObject[] monster;


    // Start is called before the first frame update
    void Start()
    {
        for ( int i = 0; i < monster.Length; i++)
        {
            timer[i] = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {   //RotDragon
        if (Dragontime.timeLeft > 0)
        {
            for (int i = 0; i < monster.Length; i++)
            {
                CreateMonster(i, 100 - percent[i]);
            }
        }
    }
       
    void CreateMonster(int num, int percent)
    {
        string tag;

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

        // 0�� : 50����
        // 1�� : 10����
        // 2�� : 3���� 

        MonsterCount[num] = GameObject.FindGameObjectsWithTag(tag);
        if (MonsterCount[num].Length < MonsterNum[num]) // ���ڸ��� �����ְ� �ڴ� [] ���������
        {
            if (timer[num] > CreateTimer[num])
            {
                int rnd = Random.Range(1, 101);
                int pos = Random.Range(10, 21);
                int posChange = Random.Range(-10, 20);
                int weight = (100 - percent) / 4;
                if (rnd > percent) // ����Ȯ��
                    {
                        Quaternion angle = Quaternion.identity;
                    if (rnd < percent + weight)
                    {
                        Vector3 position = new Vector3(pos, -posChange, 0);
                        angle.eulerAngles = new Vector3(0, 0, 180 - Mathf.Atan2(position.x, position.y) * Mathf.Rad2Deg);
                        GameObject v = Instantiate(monster[num], transform.position + position, angle);
                       // Debug.Log(num + "," + tag + "," + MonsterCount[num].Length + "," + MonsterNum[num]);
                    }
                    else if (rnd < percent + weight * 2)
                    {
                        Vector3 position = new Vector3(-pos, posChange, 0);
                        angle.eulerAngles = new Vector3(0, 0, 180 - Mathf.Atan2(position.x, position.y) * Mathf.Rad2Deg);
                        GameObject v = Instantiate(monster[num], transform.position + position, angle);
                      //  Debug.Log(num + "," + tag + "," + MonsterCount[num].Length + "," + MonsterNum[num]);
                    }

                    else if (rnd < percent + weight * 3)
                    {
                        Vector3 position = new Vector3(posChange, pos, 0);
                        angle.eulerAngles = new Vector3(0, 0, 180 - Mathf.Atan2(position.x, position.y) * Mathf.Rad2Deg);
                        GameObject v = Instantiate(monster[num], transform.position + position, angle);
                     //   Debug.Log(num + "," + tag + "," + MonsterCount[num].Length + "," + MonsterNum[num]);
                    }
                    else
                    {
                        Vector3 position = new Vector3(-posChange, -pos, 0);
                        angle.eulerAngles = new Vector3(0, 0, 180 - Mathf.Atan2(position.x, position.y) * Mathf.Rad2Deg);
                        GameObject v = Instantiate(monster[num], transform.position + position, angle);
                    //    Debug.Log(num + "," + tag + "," + MonsterCount[num].Length + "," + MonsterNum[num]);
                    }
                        //new Vector3(transform.position.x - posChange, transform.position.y-pos,transform.position) ������ġ
                        // transform.position = ���¹���
                        // ��ǥ���� - �������� = ��ǥ���� ����
                        // (- posChange, -pos)  = ���⺤��

                    }
                timer[num] = 0;
            }
            timer[num]++;
        }
    }
 
}
