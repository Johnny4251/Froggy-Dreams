using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Choice : MonoBehaviour
{
    public List<string> options = new List<string>();
    public int nextDialogueIndex;
    public int outcomeIndex;
    public string text;
    public string outcome;
    public InventoryItem itemReward;
    public string flag;
}

