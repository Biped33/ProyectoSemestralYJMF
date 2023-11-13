using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseConditions : MonoBehaviour
{
    static public WinLoseConditions instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void WinConditionLevel1()
    {
        SceneManager.LoadScene(4);
    }
    public void WinConditionLevel2()
    {

        SceneManager.LoadScene(5);
    }
    public void WinConditionLevel3()
    {

        SceneManager.LoadScene(6);
    }
    public void LoseCondition()
    {
        SceneManager.LoadScene(8);
    }
}
