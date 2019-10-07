using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    GameManager gameManager; // Gamemanager reference

    // Gameobjects for rooms
    public GameObject bathroom;
    public GameObject kitchen;
    public GameObject bedroom;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Gets gamemanager object from scene
        bathroom.SetActive(false);
        kitchen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchRooms(string roomCode, Vector3 targetPosition)
    {
        // Switch statement for roomcodes
        switch (roomCode)
        {
            case "Bedroom1":
                bedroom.SetActive(false);
                bathroom.SetActive(true);
                break;

            case "Bedroom2":
                bedroom.SetActive(false);
                kitchen.SetActive(true);
                break;

            case "Kitchen1":
                kitchen.SetActive(false);
                bedroom.SetActive(true);
                break;

            case "Bathroom1":
                bathroom.SetActive(false);
                bedroom.SetActive(true);
                break;

            default:
                Debug.Log("Invalid roomcode.");
                break;
        }

        gameManager.player.transform.position = targetPosition; // Transport player to proper location coming out of room

    }
}
