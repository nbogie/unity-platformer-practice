using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    private bool isOn;

    [SerializeField]
    private Sprite spriteLeft;
    [SerializeField]
    private Sprite spriteMid;
    [SerializeField]
    private Sprite spriteRight;
    [SerializeField]
    private bool startsOn;
    private SpriteRenderer spriteRenderer;

    private AudioSource audioSrc;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isOn = startsOn;
        UpdateRenderer();
        audioSrc = GetComponent<AudioSource>();
    }

    void UpdateRenderer()
    {
        if (isOn)
        {
            spriteRenderer.sprite = spriteRight;
        }
        else
        {
            spriteRenderer.sprite = spriteLeft;
        }
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ToggleSwitch();
    }
    void ToggleSwitch()
    {
        isOn = !isOn;
        UpdateRenderer();
        audioSrc.Play();
    }
}
