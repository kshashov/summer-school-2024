using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int Id;
    public bool Clicked = false;
    public LevelEditor Editor;
    public GameController Game;

    public void ButtonClicked() 
    {
        Vector2 mousePosition = Game.GetMouseWorldPosition();
        Clicked = true;
        Instantiate(Editor.ItemImages[Id], new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity);
        Editor.CurrentItem = Id;
    }
}
