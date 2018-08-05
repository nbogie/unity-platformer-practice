using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MyTilemapCollision : MonoBehaviour
{
    private Tilemap myTilemap;

    void Start()
    {
        myTilemap = GetComponent<Tilemap>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Vector2 cpos = coll.transform.position;
        Debug.Log("cpos: " + cpos + " cell " + myTilemap.WorldToCell(cpos));
        Debug.Log(myTilemap.GetTile(myTilemap.WorldToCell(cpos)));
    }
}
