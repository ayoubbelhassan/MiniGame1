using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    public float speed;
    public float jump;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    bool isjump = false;
    public float timer;

    private bool isshooting;

    // player eat coins
    public int coins;

    // player eat keys
    public int keys;


    // ui coins and keys
     /*
    public Transform holder;

    TextMeshProUGUI cointext;
    TextMeshProUGUI keytext;

    */

    // Start is called before the first frame update
    public float shootspeed;
    public float shoottimer;
    public Transform pos;
    public GameObject bullet;


    //scene variables 

    void Start()
    {
        

        // ui coins and keys 
        /*
        cointext = holder.Find("textcoin").GetComponent<TextMeshProUGUI>();
        keytext = holder.Find("textkey").GetComponent<TextMeshProUGUI>();
       keytext.text = keys+"/3";
       cointext.text = "" + coins;

        */

        // components 
        rb = GetComponent<Rigidbody2D>();
        sr= GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();



        


        isshooting = false;
    }

    // Update is called once per frame
    public void rightmove()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        sr.flipX = false;
        anim.SetBool("attack", false);
        
    }

    public void leftmove()
    {
        rb.velocity = new Vector2(speed*-1, rb.velocity.y);
        sr.flipX = true;
        anim.SetBool("attack", false);
    }

    public void juummp()
    {

        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            isjump = true;
        }
        else
        {
            isjump = false;
        }



        if (isjump==true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        anim.SetBool("attack", false);

    }

    public void atck()
    {
        
        if (!isshooting)
        {
            anim.SetBool("attack", true);
            
            StartCoroutine(wait());
            StartCoroutine(shoot());
        }
        

        
    }

    void Update()
    {
        

        //pc controller
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightmove();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            leftmove();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            juummp();
        }
        if (Input.GetKey(KeyCode.W))
        {
            atck();
        }



        if (Input.GetKey(KeyCode.X) && !isshooting)
        {
            StartCoroutine(shoot());
        }






    }
    IEnumerator wait()
    {
    
        yield return new WaitForSeconds(timer);
        anim.SetBool("attack", false);
        
    }


    IEnumerator shoot()
    {
        int derection()
        {
            if (sr.flipX == true)
            {
                return -1;
            }
            else
            {
                return 1;
            }

        }




        isshooting = true;

        GameObject newbullet = Instantiate(bullet, pos.position, Quaternion.identity);
        newbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootspeed * derection() * Time.fixedDeltaTime, 0f);





        yield return new WaitForSeconds(shoottimer);
        isshooting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coins")
        {
            Destroy(collision.gameObject);
            coins = coins + 1;
          //cointext.text = ""+coins;
            Debug.Log(coins);
        }

       

        if (collision.name == "dead")
        {
            Destroy(gameObject);
        }


        if (collision.tag == "key")
        {
            Destroy(collision.gameObject);
            keys = keys + 1;
            //keytext.text = keys + "/3";
            Debug.Log(keys);

        }

        if (collision.name == "port" && keys > 2)
        {
            Debug.Log("level complet");
          
        }

        if (collision.name == "dead")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }




}
