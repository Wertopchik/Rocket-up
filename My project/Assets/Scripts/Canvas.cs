using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{

    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject button;
    void Start()
    {
        pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        button.SetActive(false);
    }
    public void ReturnGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        button.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void gomenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("gomenu");
    }
}
