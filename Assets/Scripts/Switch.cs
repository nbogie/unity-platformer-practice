using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    private bool isOn;
    private bool triggered;

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
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            if (!triggered)
            {

                ToggleSwitch();
                triggered = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            if (triggered)
            {
                triggered = false;
            }
        }
    }
    void ToggleSwitch()
    {
        isOn = !isOn;
        UpdateRenderer();
        audioSrc.Play();
    }
}
