using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    Transform respawnPoint = null;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Respawn()
    {
        InternalTeleportTo(respawnPoint);
    }

    public void TeleportTo(Teleporter destination)
    {
        if (destination)
        {
            InternalTeleportTo(destination.transform);
        }
        else
        {
            throw new Exception("null destination for Teleport");

        }
    }

    void InternalTeleportTo(Transform dest)
    {
        transform.position = dest.position;
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector2.zero;
    }


    public void EndLevel()
    {
        Debug.Log("End level!");
        Debug.Log("Active Scene name: " + SceneManager.GetActiveScene().name + " buildIndex:" + SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
