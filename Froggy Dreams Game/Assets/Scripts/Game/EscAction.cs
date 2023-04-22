using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscAction : MonoBehaviour
{
    public GameObject pause;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void enPause()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void quit()
    {
        Application.Quit();
    }
}

