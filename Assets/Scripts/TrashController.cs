using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        // Delete an item
        EditableItemController item = col.gameObject.GetComponent<EditableItemController>();
        if (item != null) 
        {
            Destroy(col.gameObject);
        }
    }
}
