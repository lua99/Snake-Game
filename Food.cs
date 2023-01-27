using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;


    void Start()
    {
        RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomPosition()
    {
        Bounds bound = this.gridArea.bounds;

        float x = Random.Range(bound.min.x, bound.max.x);
        float y = Random.Range(bound.min.y, bound.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            RandomPosition();
        }
    }


}
