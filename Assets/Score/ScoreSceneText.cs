using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneText : MonoBehaviour
{
    public static ScoreSceneText instance;
    public static int[] score = new int[6];
    public static int[] Time = new int[6];
    public static string[] Clear = new string[6];
    public Text[] text = new Text[6];
    int scoretemp;
    int timetemp;
    string temp;

    private void Awake()
    {   
        if (instance != null)
        {

            Destroy(gameObject);
            return;
        }
       
        else if (instance == null)
        {
            for (int i = 0; i < 6; i++)
            {
                score[i] = 0;
                Time[i] = 0;
                Clear[i] = "";
            }
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
    }

    public void ArrangeMent()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (ScoreSceneText.score[i] < ScoreSceneText.score[i + 1])
                {
                    scoretemp = ScoreSceneText.score[i];
                    ScoreSceneText.score[i] = ScoreSceneText.score[i + 1];
                    ScoreSceneText.score[i + 1] = scoretemp;

                    timetemp = ScoreSceneText.Time[i];
                    ScoreSceneText.Time[i] = ScoreSceneText.Time[i + 1];
                    ScoreSceneText.Time[i + 1] = timetemp;

                    temp = ScoreSceneText.Clear[i];
                    ScoreSceneText.Clear[i] = ScoreSceneText.Clear[i + 1];
                    ScoreSceneText.Clear[i + 1] = temp;

                }
            }
        }
    }
}
