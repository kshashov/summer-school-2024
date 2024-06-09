using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    public GameObject Done;
    public GameController Game;
    public GameObject Tools;

    void OnTriggerEnter2D(Collider2D col)
    {
        BallController item = col.gameObject.GetComponent<BallController>();
        if (item != null)
        {
            // Delete ball and show a done window
            Destroy(col.gameObject);
            Done.SetActive(true);
            Game.Stop();
            Tools.SetActive(false);
        }
    }
}
