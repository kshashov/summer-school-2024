using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public Sprite[] Sprites;
    public GameController Game;
    private int currentSprite = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
