using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movetonextlevel : MonoBehaviour
{
    public int nextsceneload;
    // Start is called before the first frame update
    void Start()
    {
        nextsceneload = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "hero")
        {
            SceneManager.LoadScene(nextsceneload);

            if(nextsceneload>PlayerPrefs.GetInt("levelAt", nextsceneload))
            {
                PlayerPrefs.SetInt("levelAt", nextsceneload);
            }
        }
    }











}
