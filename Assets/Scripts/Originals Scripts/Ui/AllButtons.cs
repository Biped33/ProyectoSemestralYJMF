using UnityEngine;
using UnityEngine.SceneManagement;
public class AllButtons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void Loadlevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadFinalScene()
    {
        SceneManager.LoadScene(7);
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
        SceneManager.LoadScene(9);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
