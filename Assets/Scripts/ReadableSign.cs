using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadableSign : MonoBehaviour
{

    [SerializeField]
    private string msg;

    private MessageDisplayer msgDisplayer;

    void Start()
    {
        GameObject go = GameObject.Find("MessageText");
        msgDisplayer = go.GetComponent<MessageDisplayer>();

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        msgDisplayer.DisplayMessage(msg);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        msgDisplayer.Clear();
    }
}
