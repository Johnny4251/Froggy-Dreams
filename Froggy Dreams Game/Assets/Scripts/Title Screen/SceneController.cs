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
        Debug.Log(titleText.GetComponent<RectTransform>().localPosition.x);

        if(Input.GetMouseButtonDown(0) && !hasClicked)
        {
            hasClicked=true;
            bgChanged = true;
        }

        if (bgChanged && titleText.GetComponent<RectTransform>().localPosition.x <= titleTextMaxX && hasClicked)
        {
            titleText.transform.Translate(
                new Vector2(titleTextSpeed * Time.deltaTime, 0));
            
        }

        if(bgChanged && instructionText.GetComponent<RectTransform>().localPosition.x <= 3000 && hasClicked)
        {
            instructionText.transform.Translate(
                new Vector2(titleTextSpeed * 2 * Time.deltaTime, 0));
        }

        if (bgChanged && buttons.transform.localPosition.x <= titleTextMaxX-30 && hasClicked)
        {
            buttons.transform.Translate(
                new Vector2(titleTextSpeed  * 3.05f * Time.deltaTime, 0));
        }


        if(background.GetComponent<RawImage>().uvRect.x <= 0 && bgChanged)
        {
            background.GetComponent<RawImage>().uvRect = 
                new Rect(background.GetComponent<RawImage>().uvRect.x -0.5f
                    * Time.deltaTime, 0,1,1);
        }
        

    }

}
