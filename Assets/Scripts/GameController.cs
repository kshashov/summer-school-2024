using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Background;
    public GameObject Ball;
    public GameObject basket;
    public GameObject GameMenu;
    public LevelEditor Editor;
    public GameObject StartArrow;
    public GameObject Tools;
    public bool IsPlay;
    private List<Level> levels = new List<Level>();
    private int CurrentLevel = 0;

    void Start()
    {
        Ball.GetComponent<BallController>().Game = this;

        levels.Add(new Level(Resources.Load<Sprite>("Sprites/Free-Nature-Backgrounds-Pixel-Art2"), new Vector2(-1.41f, 3.22f), new Vector2(4.28f, -3.11f)));
        levels.Add(new Level(Resources.Load<Sprite>("Sprites/Free-Nature-Backgrounds-Pixel-Art3"), new Vector2(-7.3f, 2.88f), new Vector2(4.28f, -3.11f)));
        levels.Add(new Level(Resources.Load<Sprite>("Sprites/Free-Nature-Backgrounds-Pixel-Art7"), new Vector2(4.75f, 2.53f), new Vector2(-7.15f, -3.13f)));

        InitLevel();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameMenu.SetActive(!GameMenu.active);
        }
    }

    private void InitLevel()
    {
        Reset();
        Level level = levels[CurrentLevel];
        Background.GetComponent<SpriteRenderer>().sprite = level.Background;
        basket.transform.position = level.Finish;
        StartArrow.transform.position = level.Start;
        Tools.SetActive(true);
    }

    public Vector3 GetMouseWorldPosition()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public void PlayStop()
    {
        if (IsPlay)
        {
            Stop();
        }
        else
        {
            Play();
        }
    }

    public void Play()
    {
        IsPlay = true;
        Editor.Disable();
        Instantiate(Ball, levels[CurrentLevel].Start, Quaternion.identity);
    }

    public void Stop()
    {
        IsPlay = false;
        var ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null)
        {
            Destroy(ball);
        }
        Editor.Enable();
    }

    public void Reset()
    {
        Stop();
        Editor.Reset();
    }

    public void NextLevel()
    {
        CurrentLevel++;
        if (CurrentLevel == levels.Count)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        InitLevel();
    }

    public class Level
    {
        public Sprite Background { get; private set; }
        public Vector2 Start { get; private set; }
        public Vector2 Finish { get; private set; }

        public Level(Sprite Background, Vector2 Start, Vector2 Finish)
        {
            this.Background = Background;
            this.Start = Start;
            this.Finish = Finish;
        }
    }
}
