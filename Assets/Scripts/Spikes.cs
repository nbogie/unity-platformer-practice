using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    AudioSource src;
	// Use this for initialization
	void Start () {
        src = GetComponent<AudioSource>();
	}
	
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.TakeDamage(10000f);
            src.Play();
        }
    }
}
