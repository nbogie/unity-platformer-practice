using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    Transform respawnPoint = null;

    [SerializeField]
    private AudioClip teleportClip;

    [SerializeField]
    private AudioClip dieClip;

    private AudioSource audioSrc;

    private MessageDisplayer msgDisplayer;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
        GameObject go = GameObject.Find("MessageText");
        msgDisplayer = go.GetComponent<MessageDisplayer>();
    }


    public void Respawn()
    {
        AudioSource.PlayClipAtPoint(dieClip, transform.position, 1f);
        InternalTeleportTo(respawnPoint);
    }

    public void TeleportTo(Teleporter destination)
    {
        if (destination)
        {
            AudioSource.PlayClipAtPoint(teleportClip, transform.position, 1f);
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
        Debug.Log("End level!  Active Scene name: " + SceneManager.GetActiveScene().name + " buildIndex:" + SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
