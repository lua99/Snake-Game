using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;

    private List<Transform> segments;
    public Transform segmentPrefab;


    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
       

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }


    }




    private void FixedUpdate()
    {
        for(int i=segments.Count-1; i>0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        
        this.transform.position = new Vector3(Mathf.Round (this.transform.position.x )+ direction.x, Mathf.Round( this.transform.position.y) + direction.y, 0f);
    }



    private void Grow()
    {
       Transform tail= Instantiate(this.segmentPrefab);
        tail.position = segments[segments.Count - 1].position;

        segments.Add(tail);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
        }

        else if (collision.tag == "Obstacle")
        {
            SceneManager.LoadScene(0);
        }
    }




}
