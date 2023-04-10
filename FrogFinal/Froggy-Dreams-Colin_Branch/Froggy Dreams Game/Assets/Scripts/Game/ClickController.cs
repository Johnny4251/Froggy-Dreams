using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickController : MonoBehaviour
{
    public float fadeSpeed;
    private bool isActive;
    void Start()
    {
        isActive = true;
        InvokeRepeating("blink",0, fadeSpeed*2);
    }

    void Update()
    {
        
    }


    private void blink()
    {
        StartCoroutine(wait());
    }


    IEnumerator wait() {
        gameObject.GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(fadeSpeed);
        gameObject.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(fadeSpeed);
    }


}
