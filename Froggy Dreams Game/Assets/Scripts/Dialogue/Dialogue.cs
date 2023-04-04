using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    [TextArea(3, 10)]
    public int id;
    public string text;
    public List<Choice> choices;
    public InventoryItem itemReward;
}
