using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Dialogue", menuName = "Character Dialogue")]
public class CharacterDialogueData : ScriptableObject
{
    public string characterName;
    public List<DialogueData> dialogues = new List<DialogueData>();
}

[System.Serializable]
public class DialogueData
{
    public int id;
    public string text;
    public List<ChoiceData> choices = new List<ChoiceData>();
    public InventoryItemData itemReward;
}

[System.Serializable]
public class ChoiceData
{
    public string text;
    public string outcome;
    public InventoryItemData itemReward;
    public string flag;
}

[System.Serializable]
public class InventoryItemData
{
    public string itemName;
    public int quantity;
}
