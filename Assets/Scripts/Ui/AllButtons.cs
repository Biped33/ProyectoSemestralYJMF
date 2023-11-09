using UnityEngine;
using UnityEngine.SceneManagement;

public class AllButtons : MonoBehaviour
{

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void RetryButtonWin()
    {
        SceneManager.LoadScene(1);
    }
    public void RetryButtonLose()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene(4);
    }
}
