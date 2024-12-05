using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform other;
    public float moveSpeed;
    public float height = 12;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
     void Move()
     {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if(transform.position.y <= -height)
        {
            transform.position=other.position + (Vector3.up*height);
        }
     }
}
