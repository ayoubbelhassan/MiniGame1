using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelsscript : MonoBehaviour
{


    public Button[] lvlbuttons;


    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for(int i=0;i< lvlbuttons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                lvlbuttons[i].interactable = false;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
