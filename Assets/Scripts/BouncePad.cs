using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour {
    [SerializeField]
    private Sprite spriteRetracted;
    [SerializeField]
    private Sprite spriteExtended;

    [SerializeField]
    private float bounceAmount;

    private  SpriteRenderer spriteRenderer ;
    private AudioSource audioSrc;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSrc = GetComponent<AudioSource>();
        Retract();
	}

    void Extend()
    {
        spriteRenderer.sprite = spriteExtended;
        audioSrc.Play();
        Invoke("Retract", 2f);

    }
    void Retract()
    {
        spriteRenderer.sprite = spriteRetracted;
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            Extend();
            player.BounceUp(bounceAmount);
        }
    }
}
