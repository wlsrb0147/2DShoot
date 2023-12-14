using UnityEngine;
using UnityEngine.UI;

public class DragonScore : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (text1 != null)
        {
            text1.text = "Score : " + ScoreSceneText.score[5];
            text2.text = "Best Score : " + ScoreSceneText.score[0];
            text3.text = "Score : " + ScoreSceneText.score[5];
            text4.text = "Best Score : " + ScoreSceneText.score[0];
            if (ScoreSceneText.score[0] < ScoreSceneText.score[5])
            {
                text1.text = "Score\n" + ScoreSceneText.score[5];
                text2.text = "BestScore\n" + ScoreSceneText.score[5];
                text3.text = "Score\n" + ScoreSceneText.score[5];
                text4.text = "BestScore\n" + ScoreSceneText.score[5];
            }
        }
    }
}
