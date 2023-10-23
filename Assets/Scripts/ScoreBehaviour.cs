using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBehaviour : MonoBehaviour
{
    private TMP_Text textcomponent;
    private int score = 0;
    void Start()
    {
        textcomponent = GetComponent<TMP_Text>();
    }


    void Update()
    {
        textcomponent.text = "Score: " + score;
    }

    public void AddPoints(int value)
    {
        score = score + value;
    }


}
