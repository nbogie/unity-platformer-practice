using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    Dictionary<string, int> thingCount;

    void TestIt()
    {
        IncrementCountOf("potato");
        IncrementCountOf("rabbit");
        IncrementCountOf("potato");
        IncrementCountOf("potato");
        IncrementCountOf("ketchup");
        IncrementCountOf("gold");
        IncrementCountOf("gold");
        IncrementCountOf("gold");
        Debug.Log(ReportContents());
    }

    void Start()
    {
        thingCount = new Dictionary<string, int>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(ReportContents());
        }

    }
    public void IncrementCountOf(string itemName)
    {
        if (itemName.Length < 1)
        {
            throw new UnityException("No item name given");
        }
        int prevVal;
        if (thingCount.TryGetValue(itemName, out prevVal))
        {
            thingCount.Remove(itemName);
            thingCount.Add(itemName, prevVal + 1);
        }
        else
        {
            thingCount.Add(itemName, 1);
        }
    }

    public string ReportContents()
    {
        string tmp = "CONTENTS: \t";
        foreach (KeyValuePair<string, int> entry in thingCount)
        {
            tmp += entry.Key + ": " + entry.Value + "\t";
        }

        return tmp;

    }





}
