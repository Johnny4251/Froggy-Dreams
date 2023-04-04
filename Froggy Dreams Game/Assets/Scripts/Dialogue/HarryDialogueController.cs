using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HarryDialogueController : MonoBehaviour
{
    public HarryPotter harryDialogue;
    public string currentScene;

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
                }
                else
                {
                    // show dialogue
                    Debug.Log(harryDialogue.GetDialogue());
                    harryDialogue.NextDialogue();
                }
            }
            else
            {
                // dialogue finished
                Debug.Log("Dialogue finished");
            }
        }
    }
}
