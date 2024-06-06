using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameController Game;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnContinue()
    {
        GameOverPanel.SetActive(false);
        Game.Stop();
    }

    public void OnRestart()
    {
        GameOverPanel.SetActive(false);
        Game.Reset();
    }
}
