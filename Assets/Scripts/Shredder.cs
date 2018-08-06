using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Player player = coll.gameObject.GetComponent<Player>();
        if (player)
        {
            player.TakeDamage(1000000);
        }
    }
}
