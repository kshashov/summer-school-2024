using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Ball;
    public GameObject GameOver;
    public LevelEditor Editor;
    private Vector3 ballPosition;
    public bool IsPlay;

    // Start is called before the first frame update
    void Start()
    {
        Ball.GetComponent<BallController>().GameOver = GameOver;
        Debug.Log(GameOver.name);
        ballPosition = new Vector3(Ball.transform.position.x, Ball.transform.position.y, Ball.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

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
        //Stop();
        Editor.Disable();
        Instantiate(Ball, ballPosition, Quaternion.identity);
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
}
