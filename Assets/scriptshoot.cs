using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptshoot : MonoBehaviour
{

    Animator anim;
    float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hero")
        {}
        else
        {
            anim.SetBool("tira", true);
            StartCoroutine(wait());
            Destroy(gameObject);
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(timer);
    }


}
