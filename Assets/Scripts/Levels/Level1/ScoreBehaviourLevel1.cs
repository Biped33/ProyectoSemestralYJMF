using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBehaviourLevel1 : MonoBehaviour
{
    private TMP_Text enemyscore;
    private int score = 0;
    void Start()
    {
        enemyscore = GetComponent<TMP_Text>();
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
        if (score >= 2500)
        {
            WinLoseConditions.instance.WinConditionLevel1();
        }
    }
    public void SubtractPoints(int value)
    {
        score -= value;

    }

}
