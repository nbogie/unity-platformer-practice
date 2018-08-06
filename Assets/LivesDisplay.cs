using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    private bool startCalledAlready = false;
    private Text text;
    void Awake()
    {
        
        text = GetComponent<Text>();
        if (!text)
        {
            throw new UnityException("No text component in LivesDisplay!");
        }
        startCalledAlready = true;
    }

    public void DisplayLives(int lives)
    {
        if (text)
        {
            if (text.text != null)
            {

                text.text = "Lives: " + lives;
            }
            else
            {
                Debug.Log("no text.text");

            }
        }
        else
        {
            Debug.Log("no text. Start called? "+ startCalledAlready);

        }
    }
    public void Clear()
    {
        text.text = "";
    }

}
