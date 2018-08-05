using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    [SerializeField]
    Teleporter destination;

    private void OnTriggerEnter2D(Collider2D c)
    {
        Player p = c.gameObject.GetComponent<Player>();
        if (p)
        {
            if (destination)
            {
                p.TeleportTo(destination);
            }
        }
    }
}
