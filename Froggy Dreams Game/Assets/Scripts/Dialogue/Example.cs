using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    [System.Serializable]
    public class DialogueOption
    {
        public string scene;
        public List<Dialogue> dialogues = new List<Dialogue>();
        public List<Choice> choices = new List<Choice>();
        public List<Flag> flags = new List<Flag>();
    }

    public List<DialogueOption> dialogueOptions = new List<DialogueOption>();

    public DialogueOption GetDialogueOption(string scene)
    {
        foreach (DialogueOption option in dialogueOptions)
        {
            if (option.scene == scene)
            {
                return option;
            }
        }
        return null;
    }

    public Dialogue GetCurrentDialogue(string scene)
    {
        DialogueOption option = GetDialogueOption(scene);
        if (option != null && option.dialogues.Count > 0)
        {
            return option.dialogues[0];
        }
        return null;
    }

    public List<Choice> GetCurrentChoices(string scene)
    {
        DialogueOption option = GetDialogueOption(scene);
        if (option != null && option.choices.Count > 0)
        {
            return option.choices;
        }
        return null;
    }

}

public class Flag {
    private Dictionary<string, object> flagDict = new Dictionary<string, object>();

    public void SetFlag(string key, object value)
    {
        if (flagDict.ContainsKey(key))
        {
            flagDict[key] = value;
        }
        else
        {
            flagDict.Add(key, value);
        }
    }

    public object GetFlag(string key)
    {
        object value;
        flagDict.TryGetValue(key, out value);
        return value;
    }
}
