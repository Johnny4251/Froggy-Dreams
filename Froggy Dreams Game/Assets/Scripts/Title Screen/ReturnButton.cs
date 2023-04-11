using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : MonoBehaviour
{


    public GameObject settingsButtons;
    public GameObject mainButtons;
    private SettingsButton set;

    private bool retClick;

    public float onScreenMain;
    public float offScreenSet;
    // Start is called before the first frame update
    void Start()
    {
        retClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(retClick && mainButtons.transform.localPosition.x >= onScreenMain)
        {
            mainButtons.transform.Translate(
                new Vector2(-400 * Time.deltaTime, 0));
        }
        if(retClick && settingsButtons.transform.localPosition.x >= offScreenSet)
        {
            settingsButtons.transform.Translate(
                new Vector2(-400 * Time.deltaTime, 0));
        }

    }

    public void retClicked()
    {
        retClick = true;

        //set.RetButton();
    }

    /**
    public void setClicked()
    {
        retClick = false;
    }
    */

}
