using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    public GameObject Win;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        BallController item = col.gameObject.GetComponent<BallController>();
        if (item != null)
        {
            Destroy(col.gameObject);
            Win.SetActive(true);
        }
    }
}
