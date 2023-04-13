using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HarryDialogueController : MonoBehaviour
{
    public HarryPotter harryDialogue;
    public string currentScene;

    private Dialogue currentDialogue;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    
        if (currentScene == "Example Scene")
        {
            harryDialogue.dialogue.Add("Example Dialogue");
            harryDialogue.choices.Add(new Choice { text = "Option 1", outcome = "Outcome 1" });
            harryDialogue.choices.Add(new Choice { text = "Option 2", outcome = "Outcome 2" });
            harryDialogue.choices.Add(new Choice { text = "Option 3", outcome = "Outcome 3" });
            // add more dialogues and choices for this scene if needed
        }

        SetDialogue(new Dialogue { text = harryDialogue.dialogue[0] });
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!harryDialogue.IsDialogueFinished())
            {
                if (harryDialogue.HasChoices())
                {
                    // show choices
                    Choice currentChoice = harryDialogue.GetChoice(harryDialogue.choiceIndex);
                    Debug.Log("Choose: " + currentChoice.text);

                    // update dialogue controller with outcome of choice
                    harryDialogue.SetFlag(harryDialogue.choiceIndex);

                    // move to next dialogue based on the choice made
                    harryDialogue.dialogueIndex = currentChoice.outcomeIndex;
                    harryDialogue.choiceIndex = 0;

                    // if the player chooses option 2, generate additional dialogue
                    if (currentChoice.text == "Option 2")
                    {
                        harryDialogue.dialogue.Insert(harryDialogue.dialogueIndex + 1, "Additional Dialogue 1");
                        harryDialogue.dialogue.Insert(harryDialogue.dialogueIndex + 2, "Additional Dialogue 2");
                        harryDialogue.choices.Insert(harryDialogue.choiceIndex + 1, new Choice { text = "Option 2.1", outcome = "Outcome 2.1" });
                        harryDialogue.choices.Insert(harryDialogue.choiceIndex + 2, new Choice { text = "Option 2.2", outcome = "Outcome 2.2" });
                    }

                    SetDialogue(new Dialogue { text = harryDialogue.dialogue[0] });
                }
                else
                {
                    // show dialogue
                    Debug.Log(currentDialogue.text);
                    harryDialogue.NextDialogue();
                    SetDialogue(new Dialogue { text = harryDialogue.dialogue[0] });
                }
            }
            else
            {
                // dialogue finished
                Debug.Log("Dialogue finished");
            }
        }
    }

    private void SetDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        currentDialogue.text = harryDialogue.GetDialogue();
        // GetComponent<DialogueManager>().DisplayDialogue(dialogue);


        GameObject dialogueBox = GameObject.Find("DialoguePanel");
        GameObject choiceBox = GameObject.Find("ChoicePanel");

        if (currentDialogue.text != "")
        {
            // enable dialogue box and set text
            dialogueBox.SetActive(true);
            dialogueBox.transform.Find("DialogueText").GetComponent<Text>().text = currentDialogue.text;
        }
        else
        {
            // disable dialogue box
            dialogueBox.SetActive(false);
        }

        if (harryDialogue.HasChoices())
        {
            // enable choice box and set text
            choiceBox.SetActive(true);
            Choice currentChoice = harryDialogue.GetChoice(harryDialogue.choiceIndex);
            choiceBox.transform.Find("ChoiceText").GetComponent<Text>().text = currentChoice.text;
        }
        else
        {
            // disable choice box
            choiceBox.SetActive(false);
        }
    }




    
    // Handling text speed for appearing on screen
    public float characterDelay = 0.1f;

    private IEnumerator TypeText(string text)
    {
        Text dialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        dialogueText.text = ""; 

        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(characterDelay);
        }
    }



    // Handling max characters for text boxes
    public int maxCharacters = 50;

    private void DisplayDialogue(string dialogue)
    {
        Text dialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        dialogueText.text = "";

        if (dialogue.Length <= maxCharacters)
        {
            StartCoroutine(TypeText(dialogue));
        }
        else
        {
            string[] dialogueParts = SplitDialogue(dialogue);
            StartCoroutine(DisplayDialogueParts(dialogueParts));
        }
    }

    private string[] SplitDialogue(string dialogue)
    {
        string[] dialogueParts = new string[Mathf.CeilToInt((float)dialogue.Length / maxCharacters)];
        for (int i = 0; i < dialogueParts.Length; i++)
        {
            int startIndex = i * maxCharacters;
            int length = Mathf.Min(maxCharacters, dialogue.Length - startIndex);
            dialogueParts[i] = dialogue.Substring(startIndex, length);
        }
        return dialogueParts;
    }

    private IEnumerator DisplayDialogueParts(string[] dialogueParts)
    {
        for (int i = 0; i < dialogueParts.Length; i++)
        {
            yield return StartCoroutine(TypeText(dialogueParts[i]));
            if (i < dialogueParts.Length - 1)
            {
                // Display "Click to continue" message
                Text continueText = GameObject.Find("ContinueText").GetComponent<Text>();   // Game Component needs to be added in Unity
                continueText.enabled = true;
                while (!Input.GetMouseButtonDown(0))
                {
                    yield return null;
                }
                continueText.enabled = false;
            }
        }
    }


}
