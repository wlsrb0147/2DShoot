using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Dragontime : MonoBehaviour
{
    public Text text;
    public static float timeLeft = 61;
    int timeleft;
    GameObject[][] monsternum = new GameObject[4][];
    public GameObject Defeat;
    public GameObject DefeatText;
    public GameObject UI;
    public GameObject boss;
    public int time;

    // Start is called before the first frame update
    private void Awake()
    {
        boss.SetActive(false);
        DefeatText.SetActive(false);
    }
    void Start()
    {
        timeLeft = time;
        timeleft = (int)timeLeft;
        UI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("DragonPlayer") != null)
        {

            if (timeLeft < 1)
            {
                Invoke("MonsterCount", 0);
                timeleft = 0;
                text.text = "";
            }
            else if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timeleft = (int)timeLeft;
                text.text = timeleft.ToString();
            }


            if (timeLeft == -2)
            {
                Invoke("DisableMonster", 0);
                timeLeft = -3;
                if (ScoreSceneText.score[5] < 2500)
                {
                    Destroy(GameObject.FindGameObjectWithTag("DragonPlayer"));
                }
            }

        }

        if (GameObject.FindGameObjectWithTag("DragonPlayer") == null && GameObject.FindGameObjectWithTag("DragonGameOver") == null)
        {
            Invoke("defeat", 1);
        }
    }

    void defeat()
    {
        if (timeLeft <1 && ScoreSceneText.score[5] < 2500)
        {
            DefeatText.SetActive(true);
        }
        UI.SetActive(false);
        Defeat.SetActive(true);
    }


    void MonsterCount()
    {
            monsternum[0] = GameObject.FindGameObjectsWithTag("DragonMonsterRot");
            monsternum[1] = GameObject.FindGameObjectsWithTag("DragonMonsterChase");
            monsternum[2] = GameObject.FindGameObjectsWithTag("DragonMonsterRush");
            monsternum[3] = GameObject.FindGameObjectsWithTag("Dragonbullet");
            timeLeft = -2;
    }

    void DisableMonster()
    {
        for (int i = 0; i < monsternum.Length; i++)
        {
            for (int j = 0; j < monsternum[i].Length; j++)
            {
                if (i == 0)
                {
                    monsternum[i][j].gameObject.GetComponent<DragonCreateHoming>().enabled = false;
                }
                monsternum[i][j].gameObject.SetActive(false);
            }
        }
        if(ScoreSceneText.score[5] > 2500)
        {
            Invoke("EnableBoss", 2);
        }
    }

    void EnableBoss()
    {
        if(boss != null)
        {
            boss.SetActive(true);
        }
        
    }
}
