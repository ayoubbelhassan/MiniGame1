using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taharok : MonoBehaviour
{
     float speeeed=1f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, speeeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ha")
        {
            speeeed = speeeed * -1;
        }   
    }
}
