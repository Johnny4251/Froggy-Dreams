using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SettingsButton : MonoBehaviour
{
    public GameObject settings;
    /**
    public GameObject settingsButtons;
    public GameObject mainButtons1;

    private Vector2 settingsPos;
    

    private bool retClick;
    private bool setClick;
    private bool mainExist;

    public float offScreenMain;
    public float onScreenSet;

    public float onScreenMain;
    public float offScreenSet;

    // Start is called before the first frame update
    void Start()
    {

        setClick = false;
        retClick = false;
        mainExist = true;
    }

    // Update is called once per frame
    void Update()
    { 


        if (setClick && mainButtons1.transform.localPosition.x <= offScreenMain
            && mainExist)
        {
            mainButtons1.transform.Translate(
                new Vector2(400 * Time.deltaTime, 0));
        }

        if (setClick && settingsButtons.transform.localPosition.x <= onScreenSet
            && mainExist)
        {

            settingsButtons.transform.Translate(
                new Vector2(400 * Time.deltaTime, 0));
        }

        
        if (retClick && !setClick && mainButtons1.transform.localPosition.x >= onScreenMain
            && mainExist)
        {
            mainButtons1.transform.Translate(
                new Vector2(-800 * Time.deltaTime, 0));
        }
        if (retClick && !setClick && settingsButtons.transform.localPosition.x >= offScreenSet
            && mainExist)
        {

            settingsButtons.transform.Translate(
                new Vector2(-800 * Time.deltaTime, 0));
        }
        
        
        if(retClick && !setClick && mainButtons1.transform.localPosition.x <= onScreenMain
            && mainExist)
        {
            retClick = false;
            setClick = false;

            
            mainExist = false;


        }
        
       
    }

    public void SetButton()
    {
        retClick = false;
        setClick = true;
        Debug.Log("Clicked");
    }

    
    public void RetButton()
    {
        setClick = false;
        retClick = true;

    Debug.Log("Ret");
    }
    

    public void OpenSettings()
    {
        SceneManager.LoadSceneAsync("Settings");
    }

    */

    public void OpenSettings2()
    {
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }
}
