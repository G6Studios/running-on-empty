using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform exitPosition; // Location player will be transported to after using door
    public string doorTag; // Tag for determining which door has been activated

    private bool touchingDoor;

    public RoomManager roomManager; // Reference to roommanager

    // Start is called before the first frame update
    void Start()
    {
        roomManager = GameObject.Find("Rooms").GetComponent<RoomManager>();
    }

    private void Update()
    {
        if(Time.timeScale > 0) // If the game is not paused
        {
            if (Input.GetKeyDown(KeyCode.W)) // If the player presses W while in front of a door
            {
                if (touchingDoor == true)
                {
                    roomManager.SwitchRooms(doorTag, exitPosition.position);
                    GameObject.Find("GameManager").GetComponent<AudioSource>().Play();
                }
                    
                
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) // Only want the player to be able to interact with doors
        {
            touchingDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            touchingDoor = false;
        }
    }
}
