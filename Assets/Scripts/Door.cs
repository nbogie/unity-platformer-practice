using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen;

    [SerializeField]
    Sprite doorClosedTop;
    [SerializeField]
    Sprite doorClosedBase;
    [SerializeField]
    Sprite doorOpenTop;
    [SerializeField]
    Sprite doorOpenBase;

    [SerializeField]
    private SpriteRenderer doorBaseRenderer;
    [SerializeField]
    private SpriteRenderer doorTopRenderer;

    [SerializeField]
    string UnlockingItemName = "KeyYellow";

    private InventorySystem invSys;

    void OpenDoor()
    {
        doorBaseRenderer.sprite = doorOpenBase;
        doorTopRenderer.sprite = doorOpenTop;
    }

    void Start()
    {
        isOpen = false;
        UpdateDoor();
        invSys = FindObjectOfType<InventorySystem>();
        if (!invSys)
        {
            throw new UnityException("no InventorySystem found!");
        }

    }

    void UpdateDoor()
    {
        if (isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
    void ToggleDoor()
    {
        isOpen = !isOpen;
        UpdateDoor();
    }
    void CloseDoor()
    {
        doorBaseRenderer.sprite = doorClosedBase;
        doorTopRenderer.sprite = doorClosedTop;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ToggleDoor();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (invSys.ContainsAtLeastOne(UnlockingItemName))
        {
            OpenDoor();
        }
        else
        {
            //play locked door sound
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

}
