using TMPro;
using UnityEngine;

public class LifesUIBehaviour : MonoBehaviour
{
    private TMP_Text numberOfLifes;
    private int lifesNumber = 3;
    void Start()
    {
        FindObjects();
    }
    void Update()
    {
        LifesText();
    }
    public void LifesText()
    {
        numberOfLifes.text = "Life: " + lifesNumber;
    }
    public void AddLifes(int value)
    {
        lifesNumber += value;
    }
    public void SubstractLifes(int value)
    {
        lifesNumber -= value;
    }

    private void FindObjects()
    {
        numberOfLifes = GetComponent<TMP_Text>();
    }
}
