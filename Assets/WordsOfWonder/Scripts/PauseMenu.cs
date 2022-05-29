using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneLoader.LoadMainMenu();
    }
}
