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
    public void WinCondition()
    {

        SceneManager.LoadScene(2);
    }

    public void LoseCondition()
    {
        SceneManager.LoadScene(3);
    }
}
