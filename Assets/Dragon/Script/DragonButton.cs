using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonButton : MonoBehaviour
{
    GameObject[][] monsternum = new GameObject[4][];
    public int SceneName;

    public void startButton()
    {
        monsternum[0] = GameObject.FindGameObjectsWithTag("DragonMonsterRot");
        monsternum[1] = GameObject.FindGameObjectsWithTag("DragonMonsterChase");
        monsternum[2] = GameObject.FindGameObjectsWithTag("DragonMonsterRush");
        monsternum[3] = GameObject.FindGameObjectsWithTag("Dragonbullet");

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
        SceneManager.LoadScene("Dragon");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
