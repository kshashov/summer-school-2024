using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditableItemController : MonoBehaviour
{
    private Collider2D col;
    private Vector3 screenPos;
    private float angleOffset;
    private Vector3 dragOffset;
    private bool dragged;
    public bool IsMovable = true;


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        //Game = GameObject.FindGameObjectWithTag("Game").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMovable) { 
            return; 
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (col == Physics2D.OverlapPoint(mousePosition))
        {
            // Rotation
            if (Input.GetMouseButtonDown(1))
            {
                screenPos = Camera.main.WorldToScreenPoint(transform.position);
                Vector2 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;

            }
            if (Input.GetMouseButton(1))
            {
                Vector2 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
            }

            // Dragging
            if (Input.GetMouseButtonDown(0))
            {
                dragged = true;
                dragOffset = transform.position - mousePosition;
            }

            if (dragged)
            {
                transform.position = mousePosition + dragOffset;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragged = false;
        }
    }
}
