using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameController Game;

    public void OnMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnNext()
    {
        GameOverPanel.SetActive(false);
        Game.NextLevel();
    }
}
