using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class BallController : MonoBehaviour
{
    public GameController Game;

    void Update()
    {
        if (!IsVisible())
        {
            Game.Stop();
        }

    }

    public bool IsVisible()
    {
        // If is on the screen
        var camera = FindObjectOfType<Camera>();
        var position = camera.WorldToScreenPoint(transform.position);
        var isOnScreen = position.x > 0f && position.x < UnityEngine.Screen.width && position.y > 0f && position.y < UnityEngine.Screen.height;

        return isOnScreen;
    }
}
