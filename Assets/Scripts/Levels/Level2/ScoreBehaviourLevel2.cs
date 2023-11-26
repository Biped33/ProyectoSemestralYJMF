using UnityEngine;
using TMPro;
public class ScoreBehaviourLevel2 : MonoBehaviour
{
    private TMP_Text enemyscore;
    private int score = 0;
    void Start()
    {
       FindObjects();
    }
    void Update()
    {
        ScoreTexts();
    }
    private void ScoreTexts()
    {
        enemyscore.text = "Score: " + score;
    }
    public void AddPoints(int value)
    {
        score += value;
        if (score >= 6000)
        {
            WinLoseConditions.instance.WinConditionLevel2();
        }
    }
    public void SubtractPoints(int value)
    {
        score -= value;

    }

    private void FindObjects()
    {
        enemyscore = GetComponent<TMP_Text>();
    }
}
