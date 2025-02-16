using UnityEngine;
using UnityEngine.SceneManagement;

public class Panels : MonoBehaviour
{
    // Getting Panels
    [SerializeField] private GameObject PauseCanvas;
    [SerializeField] private GameObject LoseCanvas;
    [SerializeField] private GameObject WinCanvas;
    [SerializeField] private GameObject PauseButton;

    public void Start()
    {
        PauseButton.SetActive(true);
    }

    public void Pause()
    {
        PauseButton.SetActive(false);
        PauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        PauseButton.SetActive(true);
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
        PauseButton.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        LoseCanvas.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void Win()
    {
        WinCanvas.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }
}
