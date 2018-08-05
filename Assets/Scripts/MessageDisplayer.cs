using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplayer : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();

    }
    public void DisplayMessage(string msg)
    {
        text.text = msg;
    }
    public void Clear()
    {
        text.text = "";
    }
    void Update()
    {

    }
}
