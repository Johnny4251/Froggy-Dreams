using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// DO NOT TOUCH SCRIPT UNLESS YOU KNOW WHAT YOU ARE DOING!
/// IF YOU WISH TO MODIFY DIALOG, CREATE YOUR OWN SCRIPT!!!
/// This script is what creates the methods that YOUR
/// script to change dialog uses ;)
/// </summary>
public class DialogController : MonoBehaviour
{
    [Header("Dialog Objects")]
    public GameObject nameText;
    public GameObject dialogText;

    [Header("Dialogs to Display in order")]
    public List<string> dialogList = new List<string>();

    [Space(10)]
    public float scrollDelay;
    

    private int currDialog;

    void Start()
    {
        changeName("Robert");
        changeDialogText("What-? Why is Everyone Frogs??...", true);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            nextDialog();
        }
    }

    
    public void changeText(GameObject dialog, string text, bool willScroll)
    {
        dialog.GetComponent<TextMeshProUGUI>().SetText(text);

        if (willScroll)
        {
            StartCoroutine(displayText(scrollDelay / 10));

            IEnumerator displayText(float seconds)
            {
                for (int i = 1; i <= text.Length; i++)
                {
                    string currText = text.Substring(0, i);
                    dialog.GetComponent<TextMeshProUGUI>().SetText(currText);
                    yield return new WaitForSeconds(seconds);
                }
            }
        }
        else { dialog.GetComponent<TextMeshProUGUI>().SetText(text); }
    }

    public void changeName(string name)
    {
        changeText(nameText, name, false);
    }

    public void changeDialogText(string text, bool willScroll)
    {
        changeText(dialogText, text, willScroll);
    }

    public void nextDialog()
    {
        changeDialogText(dialogList[currDialog], true);
        currDialog++;
    }
}
