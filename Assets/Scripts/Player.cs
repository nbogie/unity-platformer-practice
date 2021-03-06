﻿using System;
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

    [SerializeField]
    private int startingLives;


    private Rigidbody2D rb;
    private int lives;
    private LivesDisplay livesDisplay;

    private CameraShake shake;
    void Start()
    {
        lives = startingLives;
        shake = Camera.main.GetComponent<CameraShake>();

        rb = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();

        livesDisplay = FindObjectOfType<LivesDisplay>();
        msgDisplayer = FindObjectOfType<MessageDisplayer>();
        if (!livesDisplay)
        {
            throw new UnityException("Can't find livesDisplay");
        }
        livesDisplay.DisplayLives(lives);
    }


    private void Respawn()
    {
        AudioSource.PlayClipAtPoint(dieClip, transform.position, 1f);
        InternalTeleportTo(respawnPoint);
    }

    internal void BounceUp(float bounceAmount)
    {
        //TODO: this probably has to go through the character controller script's movement system.
        rb.AddForce(Vector2.up * bounceAmount, ForceMode2D.Impulse);
    }

    internal void TakeDamage(float damage)
    {
        shake.StartToShake(1f);
        //TODO: restart level (e.g. water-level, etc)
        Die();
    }

    private void Die()
    {
        lives--;
        livesDisplay.DisplayLives(lives);
        if (lives > 0)
        {
            Respawn();
        }
        else
        {
            SceneManager.LoadScene("GameOverLoseScene");                
        }
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
