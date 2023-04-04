using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialogueBox;
    public GameObject choicesBox;
    public GameObject choicePrefab;
    public HarryDialogueController example;

    private int dialogueIndex = 0;
    private List<GameObject> choiceGameObjects = new List<GameObject>();

    public void StartDialogue(string scene)
    {
        dialogueIndex = 0;
        DisplayDialogue(new Dialogue {text = scene});
    }

    public void DisplayDialogue(Dialogue dialogue)
    {
        string text = dialogue.text;
        dialogueText.text = text;
        dialogueBox.SetActive(true);
    
        List<Choice> choices = dialogue.choices;
        if (choices != null)
        {
            DisplayChoices(choices);
        }
    
        if (dialogue.itemReward != null)
        {
            Inventory inventory = GetComponent<Inventory>();
            InventoryItem inventoryItem = new InventoryItem(dialogue.itemReward.itemName);
            inventory.AddItem(inventoryItem);
        }
    }
    public void DisplayChoices(List<Choice> choices)
    {
        ClearChoices();

        foreach (Choice choice in choices)
        {
            GameObject choiceObject = Instantiate(choicePrefab, choicesBox.transform);
            choiceObject.GetComponentInChildren<Text>().text = choice.text;
            choiceObject.GetComponent<Button>().onClick.AddListener(() => Choose(choice));
            choiceGameObjects.Add(choiceObject);

            if (choice.itemReward != null)
            {
                Inventory inventory = new Inventory();
                inventory.AddItem(choice.itemReward);
            }
        }

        choicesBox.SetActive(true);
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        ClearChoices();
    }

    public void Choose(Choice choice)
    {
        string outcome = choice.outcome;
        if(!string.IsNullOrEmpty(outcome))
        {
            example.harryDialogue.scene = outcome;
            dialogueIndex = 0;
        }
        EndDialogue();

        if (!string.IsNullOrEmpty(choice.flag))
        {
            Flag flags = new Flag();
            flags.SetFlag(choice.flag, true);
        }
        if (choice.itemReward != null)
        {
            Inventory inventory = new Inventory();
            inventory.AddItem(choice.itemReward);
        }
    }


    public void ClearChoices()
    {
        foreach (GameObject choiceObject in choiceGameObjects)
        {
            Destroy(choiceObject);
        }
        choiceGameObjects.Clear();
        choicesBox.SetActive(false);
    }
}
