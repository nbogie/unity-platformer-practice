﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    private Dictionary<string, int> thingCount;
    private InventoryDisplay inventoryDisplay;

    private void Start()
    {
     inventoryDisplay = FindObjectOfType<InventoryDisplay>();
    }
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

    void Awake()
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

        inventoryDisplay.DisplayInventory(this);
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

    public bool ContainsAtLeastOne(string key)
    {
        
        int n;
        if (thingCount.TryGetValue(key, out n))
        {
            return n > 0;
        }
        else
        {
            return false;
        }
    }
}
