using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    public GameController Game;
    public ItemController[] ItemButtons;
    public GameObject[] ItemPrefabs;
    public GameObject[] ItemImages;
    public int CurrentItem = 0;
    public bool Enabled = false;

    public void Update()
    {
        Vector2 mousePosition = Game.GetMouseWorldPosition();

        // Create a new item if preview is placed
        if (Input.GetMouseButtonDown(0) && ItemButtons[CurrentItem].Clicked)
        {
            ItemButtons[CurrentItem].Clicked = false;
            Instantiate(ItemPrefabs[CurrentItem], new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity);
            Destroy(GameObject.FindGameObjectWithTag("ItemPreview"));
        }
    }

    public void Disable()
    {
        Destroy(GameObject.FindGameObjectWithTag("ItemPreview"));
        for (int i = 0; i < ItemButtons.Length; i++)
        {
            ItemButtons[i].Clicked = false;
            ItemButtons[i].gameObject.SetActive(false);
        }

        var items = GameObject.FindGameObjectsWithTag("Item");
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<EditableItemController>().IsMovable = false;
        }
    }

    public void Enable()
    {
        Destroy(GameObject.FindGameObjectWithTag("ItemPreview"));
        for (int i = 0; i < ItemButtons.Length; i++)
        {
            ItemButtons[i].gameObject.SetActive(true);
        }

        var items = GameObject.FindGameObjectsWithTag("Item");
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<EditableItemController>().IsMovable = true;
        }
    }

    public void Reset()
    {
        var items = GameObject.FindGameObjectsWithTag("Item");
        for (int i = 0; i < items.Length; i++)
        {
            Destroy(items[i]);
        }
        Enable();
    }

}
