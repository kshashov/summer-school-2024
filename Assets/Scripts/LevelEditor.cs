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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        Vector2 mousePosition = Game.GetMouseWorldPosition();

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
    }

    public void Enable()
    {
        Destroy(GameObject.FindGameObjectWithTag("ItemPreview"));
        for (int i = 0; i < ItemButtons.Length; i++)
        {
            ItemButtons[i].gameObject.SetActive(true);
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
