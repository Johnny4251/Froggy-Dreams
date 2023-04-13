using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    [TextArea(3, 10)]
    public int id;
    public string text;
    public string outcome;
    public List<Choice> choices;
    public InventoryItem itemReward;
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