using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {
    Text text;

	void Start () {
        text = GetComponent<Text>();	
	}
	
	void Update () {
	}

    public void DisplayInventory(InventorySystem isys)
    {
        text.text = isys.ReportContents();

    }
}
