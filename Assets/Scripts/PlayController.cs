using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public Sprite[] Sprites;
    public GameController Game;
    private int currentSprite = 0;

    void Update()
    {
        // Update the immage according to the current game state
        int sprite = Game.IsPlay ? 1 : 0;
        if (currentSprite != sprite)
        {
            GetComponent<Image>().sprite = Sprites[sprite];
            currentSprite = sprite;
        }
    }

    public void ButtonClicked()
    {
        Game.PlayStop();
    }

    public void OnReset()
    {
        Game.Reset();
    }
}
