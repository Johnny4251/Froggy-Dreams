using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public GameObject titleText;
    public GameObject instructionText;

    public GameObject buttons;

    public GameObject background;
    public Texture2D backgroundOne;
    public Texture2D backgroundTwo;

    private bool hasClicked;
    private bool bgChanged; 
    

    public float titleTextSpeed;
    public float titleTextMaxX;

    void Start()
    {
        hasClicked = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !hasClicked)
        {
            hasClicked=true;
            bgChanged = true;
        }

        if (bgChanged && titleText.transform.position.x <= titleTextMaxX && hasClicked)
        {
            titleText.transform.Translate(
                new Vector2(titleTextSpeed * Time.deltaTime, 0));
            
        }

        if(bgChanged && instructionText.transform.position.x <= 2500 && hasClicked)
        {
            instructionText.transform.Translate(
                new Vector2(titleTextSpeed * Time.deltaTime, 0));
        }

        if (bgChanged && buttons.transform.position.x <= titleTextMaxX - 100 && hasClicked)
        {
            buttons.transform.Translate(
                new Vector2(titleTextSpeed * Time.deltaTime, 0));
        }


        Debug.Log(background.GetComponent<RawImage>().uvRect.x);
        if(background.GetComponent<RawImage>().uvRect.x <= 0 && bgChanged)
        {
            background.GetComponent<RawImage>().uvRect = 
                new Rect(background.GetComponent<RawImage>().uvRect.x -0.5f
                    * Time.deltaTime, 0,1,1);
        }
        

    }

}
