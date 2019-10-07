using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{

    private bool touchingDoor;
    GameManager gameManager;
    ObjectiveManager objectiveManager;
    public Animator unfinishedTasks;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        objectiveManager = GameObject.Find("ObjectiveManager").GetComponent<ObjectiveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0) // If the game is not paused
        {
            if (Input.GetKeyDown(KeyCode.W)) // If the player presses W while in front of a door
            {
                if (touchingDoor == true)
                {
                    if(CheckObjectives() > 0)
                    {
                        unfinishedTasks.SetTrigger("Unfinished");
                        Debug.Log("There are still objectives you need to do!");
                    }
                    
                    else
                    {
                        gameManager.exit = true;
                        GameObject.Find("GameManager").GetComponent<AudioSource>().Play();
                    }
                }
                    
            }
        }
    }

    private int CheckObjectives() // Checking to see if the player has completed all objectives
    {
        int remainingObjectives = 0; // Variable for counting incomplete (active) objectives

        for (int i = 0; i < objectiveManager.objectives.Length; i++) // For all objectives in the manager
        {
            if(objectiveManager.objectives[i].enabled == true) // If it is incomplete
            {
                remainingObjectives++; // Increment remainingobjectives
            }
        }

        Debug.Log(remainingObjectives);
        return remainingObjectives; // Return remainingobjectives
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Only want the player to be able to interact with doors
        {
            touchingDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            touchingDoor = false;
        }
    }
}
