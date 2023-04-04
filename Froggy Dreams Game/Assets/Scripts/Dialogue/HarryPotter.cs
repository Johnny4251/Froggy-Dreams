using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Harry Dialogue", menuName = "Dialogue/Harry Dialogue")]
public class HarryPotter : ScriptableObject
{
    [TextArea(3, 10)]
    public List<string> dialogue = new List<string>();
    public List<Choice> choices = new List<Choice>();
    public string scene;

    public int dialogueIndex;
    public int choiceIndex;
    public bool[] flags = new bool[10];

    public void NextDialogue()
    {
        dialogueIndex++;
        choiceIndex = 0;
    }

    public bool IsDialogueFinished()
    {
        return dialogueIndex >= dialogue.Count;
    }

    public bool HasChoices()
    {
        return choiceIndex < choices[dialogueIndex].options.Count;
    }

    public string GetDialogue()
    {
        return dialogue[dialogueIndex];
    }

    public Choice GetChoice(int choiceNumber)
    {
        return choices[dialogueIndex];
    }

    public void SetFlag(int flagIndex)
    {
        flags[flagIndex] = true;
    }

    public bool CheckFlag(int flagIndex)
    {
        return flags[flagIndex];
    }
}
