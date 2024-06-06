using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class BallController : MonoBehaviour
{
    private Camera camera;
    private Renderer renderer;
    public GameObject GameOver;

    public bool IsGameOver { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGameOver)
        {
            if (!IsVisible())
            {
                IsGameOver = true;
                GameOver.SetActive(true);
            }
        }
    }

    public bool IsVisible()
    {
        var position = camera.WorldToScreenPoint(transform.position);
        var isOnScreen = position.x > 0f && position.x < UnityEngine.Screen.width && position.y > 0f && position.y < UnityEngine.Screen.height;

        return isOnScreen;
    }
}